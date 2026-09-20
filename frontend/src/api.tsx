import axios from "axios";
import { CompanyProfile, CompanySearch } from "./company";

interface SearchResponse {
  data: CompanySearch[];
}
export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/stable/search-name?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error message: ", error.message);
      return error.message;
    } else {
      console.error("Unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};

export const getCompanyProfile = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyProfile[]>(
      `https://financialmodelingprep.com/stable/profile?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error message: ", error.message);
      return error.message;
    } else {
      console.error("Unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};
