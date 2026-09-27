import axios from "axios";
import {
  CompanyBalanceSheet,
  CompanyCashFlow,
  CompanyCompData,
  CompanyIncomeStatement,
  CompanyKeyMetrics,
  CompanyProfile,
  CompanySearch,
} from "../company";

interface SearchResponse {
  data: CompanySearch[];
}

const handleError = (error: unknown): string => {
  if (axios.isAxiosError(error)) {
    console.error("Error message: ", error.message);
    if (error.response?.status === 402) {
      return "This symbol isn't available on the free plan.";
    }
    return error.message;
  } else {
    console.error("Unexpected error: ", error);
    return "An Unexpected error has occured.";
  }
};

export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/stable/search-name?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    return handleError(error);
  }
};

export const getCompanyProfile = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyProfile[]>(
      `https://financialmodelingprep.com/stable/profile?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    return handleError(error);
  }
};

export const getKeyMetrics = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyKeyMetrics[]>(
      `https://financialmodelingprep.com/stable/key-metrics-ttm?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    return handleError(error);
  }
};
export const getIncomeStatement = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyIncomeStatement[]>(
      `https://financialmodelingprep.com/stable/income-statement?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );
    return data;
  } catch (error) {
    return handleError(error);
  }
};

export const getBalanceSheetData = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyBalanceSheet[]>(
      `https://financialmodelingprep.com/stable/balance-sheet-statement?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );

    return data;
  } catch (error) {
    return handleError(error);
  }
};

export const getCashFlowData = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyCashFlow[]>(
      `https://financialmodelingprep.com/stable/cash-flow-statement?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );

    return data;
  } catch (error) {
    return handleError(error);
  }
};

export const getCompData = async (ticker: string) => {
  try {
    const data = await axios.get<CompanyCompData[]>(
      `https://financialmodelingprep.com/stable/stock-peers?symbol=${ticker}&apikey=${process.env.REACT_APP_API_KEY}`,
    );

    return data;
  } catch (error) {
    return handleError(error);
  }
};
