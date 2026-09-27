import { SyntheticEvent } from "react";
import { CompanySearch } from "../../company";
import Card from "../Card/Card";

interface Props {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList = ({ searchResults, onPortfolioCreate }: Props) => {
  return (
    <>
      {searchResults.length > 0 ? (
        searchResults.map((company) => (
          <Card
            id={company.symbol}
            key={company.symbol}
            searchResult={company}
            onPortfolioCreate={onPortfolioCreate}
          />
        ))
      ) : (
        <p className="mb-3 mt-6 text-lg font-medium text-center text-slate-500">
          No results!
        </p>
      )}
    </>
  );
};

export default CardList;
