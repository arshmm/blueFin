import { createContext, useEffect, useState } from "react";
import { UserProfile } from "../Models/User";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../Services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";
import { getTokenExpiry, isTokenExpired } from "../Util/jwt";
import { isSessionRejected } from "../Helpers/ErrorHandler";

type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  registerUser: (email: string, username: string, password: string) => void;
  loginUser: (username: string, password: string, redirectTo?: string) => void;
  logout: (expired?: boolean) => void;
  isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const user = localStorage.getItem("user");
    const token = localStorage.getItem("token");
    if (user && token) {
      if (isTokenExpired(token)) {
        // Quietly drop a stale session instead of restoring it
        localStorage.removeItem("token");
        localStorage.removeItem("user");
      } else {
        setUser(JSON.parse(user));
        setToken(token);
        axios.defaults.headers.common["Authorization"] = "Bearer " + token;
      }
    }
    setIsReady(true);
  }, []);

  // Log out the moment the token expires while the app is open
  useEffect(() => {
    if (!token) return;

    const expiry = getTokenExpiry(token);
    if (!expiry) return;

    const timer = setTimeout(() => logout(true), expiry - Date.now());
    return () => clearTimeout(timer);
    // logout only uses setters, localStorage and navigate, so it never goes stale
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token]);

  // Log out when the API rejects the token (expired, tampered, key changed)
  useEffect(() => {
    const id = axios.interceptors.response.use(
      (response) => response,
      (error) => {
        // The token check stops parallel failing requests from logging out twice
        if (isSessionRejected(error) && localStorage.getItem("token")) {
          logout(true);
        }
        return Promise.reject(error);
      },
    );
    return () => axios.interceptors.response.eject(id);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const registerUser = async (
    email: string,
    username: string,
    password: string,
  ) => {
    await registerAPI(email, username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          const userObj = {
            userName: res?.data.userName,
            email: res?.data.email,
          };
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token!);
          setUser(userObj!);
          axios.defaults.headers.common["Authorization"] =
            "Bearer " + res?.data.token;
          toast.success("Login Success!");
          navigate("/search");
        }
      })
      .catch((e) => toast.warning("Server error occured"));
  };

  const loginUser = async (
    username: string,
    password: string,
    redirectTo: string = "/search",
  ) => {
    await loginAPI(username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          const userObj = {
            userName: res?.data.userName,
            email: res?.data.email,
          };
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token!);
          setUser(userObj!);
          axios.defaults.headers.common["Authorization"] =
            "Bearer " + res?.data.token;
          toast.success("Login Success!");
          navigate(redirectTo);
        }
      })
      .catch((e) => toast.warning("Server error occured"));
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = (expired: boolean = false) => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken("");
    delete axios.defaults.headers.common["Authorization"];
    if (expired) {
      toast.warning("Session expired. Please log in again.");
      navigate("/login");
    } else {
      navigate("/");
    }
  };

  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);
