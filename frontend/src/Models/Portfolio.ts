export type PortfolioGet = {
  id: number;
  symbol: string;
  companyName: string;
  purchase: number;
  lastDividend: number;
  industry: string;
  marketCap: number;
  comments: any;
};

export type PortfolioPost = {
  symbol: string;
};
