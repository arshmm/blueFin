import { SyntheticEvent } from "react";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";
import { Link } from "react-router-dom";

interface Props {
  portfolioValue: string;
  onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
  return (
    <div className="flex flex-col w-full p-6 space-y-4 text-center rounded-xl border border-slate-800 bg-slate-900 shadow-xl shadow-black/30 transition hover:border-lightBlue/50">
      <Link
        to={`/company/${portfolioValue}/company-profile`}
        className="pt-2 text-2xl font-bold tracking-wide text-slate-100 transition-colors hover:text-lightBlue"
      >
        {portfolioValue}
      </Link>
      <DeletePortfolio
        portfolioValue={portfolioValue}
        onPortfolioDelete={onPortfolioDelete}
      />
    </div>
  );
};

export default CardPortfolio;
