import React, { JSX, SyntheticEvent } from "react";
import "./Card.css";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
import { Link } from "react-router-dom";

interface Props {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({
  id,
  searchResult,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <div
      className="flex flex-col items-center justify-between w-full gap-3 p-5 rounded-xl border border-slate-800 bg-slate-900/70 transition hover:border-slate-700 hover:bg-slate-900 md:flex-row"
      id={id}
    >
      <Link
        to={`/company/${searchResult.symbol}/company-profile`}
        className="font-semibold text-center text-slate-100 transition-colors hover:text-lightBlue md:text-left"
      >
        {searchResult.name} ({searchResult.symbol})
      </Link>
      <p className="rounded-md bg-slate-800 px-2 py-0.5 text-xs font-medium text-slate-400">
        {searchResult.currency}
      </p>
      <p className="text-sm text-slate-400">
        {searchResult.exchangeFullName} - {searchResult.exchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={onPortfolioCreate}
        symbol={searchResult.symbol}
      />
    </div>
  );
};

export default Card;
