import { Link } from "react-router-dom";
import logo from "./logo.svg";
import "./Navbar.css";
import { useAuth } from "../../Context/useAuth";

interface Props {}

const Navbar = (props: Props) => {
  const { isLoggedIn, user, logout } = useAuth();
  return (
    <nav className="sticky top-0 z-50 w-full border-b border-slate-800/80 bg-slate-950/80 backdrop-blur">
      <div className="container mx-auto flex items-center justify-between px-6 py-4">
        <div className="flex items-center space-x-12">
          <Link to="/" className="transition-opacity hover:opacity-80">
            <img src={logo} alt="" className="h-9 w-auto" />
          </Link>
          <div className="hidden items-center space-x-8 text-sm font-medium lg:flex">
            <Link
              to="/search"
              className="text-slate-300 transition-colors hover:text-white"
            >
              Search
            </Link>
            <Link
              to="/portfolio"
              className="text-slate-300 transition-colors hover:text-white"
            >
              Portfolio
            </Link>
            <Link
              to="/design"
              className="text-slate-300 transition-colors hover:text-white"
            >
              Design
            </Link>
          </div>
        </div>
        {isLoggedIn() ? (
          <div className="hidden items-center space-x-6 text-sm font-medium lg:flex">
            <div className="text-slate-300">Welcome, {user?.userName}</div>
            <button
              type="button"
              onClick={logout}
              className="rounded-lg bg-lightGreen px-5 py-2.5 font-semibold text-slate-950 shadow-lg shadow-lightGreen/20 transition hover:brightness-110"
            >
              Logout
            </button>
          </div>
        ) : (
          <div className="hidden items-center space-x-6 text-sm font-medium lg:flex">
            <Link
              to="/login"
              className="text-slate-300 transition-colors hover:text-white"
            >
              Login
            </Link>
            <Link
              to="/register"
              className="rounded-lg bg-lightGreen px-5 py-2.5 font-semibold text-slate-950 shadow-lg shadow-lightGreen/20 transition hover:brightness-110"
            >
              Signup
            </Link>
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
