export type PortfolioGet = {
  symbol: string;
  companyName: string;
  industry: string;
  shares: number;
  avgCost: number;
  purchasedOn: string | null;
  costBasis: number;
  // Live quote values are null when FMP has no price for the symbol
  price: number | null;
  change: number | null;
  changePercentage: number | null;
  marketValue: number | null;
  dayChange: number | null;
  gainLoss: number | null;
  gainLossPercentage: number | null;
};

export type PortfolioPost = {
  symbol: string;
  shares: number;
  avgCost?: number;
  purchasedOn?: string;
};

export type PortfolioPut = {
  shares: number;
  avgCost: number;
  purchasedOn?: string | null;
};
