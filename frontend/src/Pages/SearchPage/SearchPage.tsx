import { ChangeEvent, SyntheticEvent, useState } from "react";
import { searchCompanies } from "../../Util/api";
import { CompanySearch } from "../../company";
import CardList from "../../Components/CardList/CardList";
import ListPortfolio from "../../Components/Portfolio/ListPortfolio/ListPortfolio";
import Search from "../../Components/Search/Search";

interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

  const handleSearchChange = (
    e: ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    setSearch(e.target.value);
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);

    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
      setServerError(null);
    }
    console.log(result);
  };

  const onPortfolioCreate = (e: SyntheticEvent) => {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const symbol = formData.get("symbol");
    if (portfolioValues.includes(symbol as string)) {
      return;
    }
    setPortfolioValues([...portfolioValues, symbol as string]);
    console.log(`Adding ${symbol} to portfolio`);
  };

  const onPortfolioDelete = (e: SyntheticEvent) => {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const symbol = formData.get("symbol");
    setPortfolioValues(portfolioValues.filter((value) => value !== symbol));
    console.log(`Deleting ${symbol} from portfolio`);
  };
  return (
    <div className="App pb-16">
      <Search
        onSearchSubmit={onSearchSubmit}
        handleSearchChange={handleSearchChange}
        search={search}
      />
      {serverError && (
        <h1 className="mx-auto mb-6 max-w-4xl rounded-xl border border-red-500/30 bg-red-500/10 px-4 py-3 text-center font-medium text-red-300">
          {serverError}
        </h1>
      )}
      <ListPortfolio
        portfolioValues={portfolioValues}
        onPortfolioDelete={onPortfolioDelete}
      />
      <div className="mx-auto max-w-5xl space-y-3 px-6">
        <CardList
          searchResults={searchResult}
          onPortfolioCreate={onPortfolioCreate}
        />
      </div>
    </div>
  );
};

export default SearchPage;
