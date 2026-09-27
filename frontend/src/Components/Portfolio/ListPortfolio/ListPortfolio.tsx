import { SyntheticEvent } from "react";
import CardPortfolio from "../CardPortfolio/CardPortfolio";

interface Props {
  portfolioValues: string[];
  onPortfolioDelete: (e: SyntheticEvent) => void;
}

const ListPortfolio = ({ portfolioValues, onPortfolioDelete }: Props) => {
  return (
    <section id="portfolio">
      <h2 className="mb-4 mt-6 text-3xl font-bold tracking-tight text-center text-white md:text-4xl">
        My Portfolio
      </h2>
      <div className="relative mx-auto mb-10 grid max-w-5xl grid-cols-1 gap-6 px-10 sm:grid-cols-2 md:grid-cols-3 md:px-6">
        <>
          {portfolioValues.length > 0 ? (
            portfolioValues.map((portfolioValue) => {
              return (
                <CardPortfolio
                  portfolioValue={portfolioValue}
                  onPortfolioDelete={onPortfolioDelete}
                  key={portfolioValue}
                />
              );
            })
          ) : (
            <h3 className="col-span-full w-full rounded-xl border border-dashed border-slate-700 py-6 text-center text-base font-medium text-slate-500">
              Your portfolio is empty.
            </h3>
          )}
        </>
      </div>
    </section>
  );
};

export default ListPortfolio;
