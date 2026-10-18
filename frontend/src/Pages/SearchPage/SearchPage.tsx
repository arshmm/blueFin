import { ChangeEvent, SyntheticEvent, useState } from "react";
import { searchCompanies } from "../../Util/api";
import { CompanySearch } from "../../company";
import CardList from "../../Components/CardList/CardList";
import Search from "../../Components/Search/Search";
import { portfolioAddAPI } from "../../Services/PortfolioService";
import { toast } from "react-toastify";

interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

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
    const symbol = formData.get("symbol") as string;
    portfolioAddAPI(symbol)
      .then((res) => {
        if (res?.status === 201) {
          toast.success(`${symbol} added to portfolio!`);
        }
      })
      .catch((e) => {
        toast.warning("Could not add stock to portfolio!");
      });
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
