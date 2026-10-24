import axios from "axios";
import { toast } from "react-toastify";

const API_BASE = "http://localhost:5137/api/";

// A 401 from our API outside login/register means the session is no longer valid.
// FMP calls share axios but are excluded (FMP returns 401 for a bad API key).
export const isSessionRejected = (error: unknown): boolean => {
  if (!axios.isAxiosError(error)) return false;
  const url = error.config?.url ?? "";
  return (
    error.response?.status === 401 &&
    url.startsWith(API_BASE) &&
    !url.includes("/account/")
  );
};

export const handleError = (error: any) => {
  if (axios.isAxiosError(error)) {
    // The axios interceptor in useAuth already logs out and shows a toast
    if (isSessionRejected(error)) return;

    const err = error.response;
    if (Array.isArray(err?.data.errors)) {
      for (let val of err?.data.errors) {
        toast.warning(val.description);
      }
    } else if (typeof err?.data.errors === "object") {
      for (let e in err?.data.errors) {
        toast.warning(err.data.errors[e][0]);
      }
    } else if (err?.data) {
      toast.warning(err.data);
    } else if (err) {
      toast.warning(err?.data);
    }
  }
};
