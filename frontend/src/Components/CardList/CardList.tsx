import { CompanySearch } from "../../company";
import Card from "../Card/Card";
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: CompanySearch[];
}

const CardList = ({ searchResults }: Props) => {
  return (
    <>
      {searchResults.length > 0 ? (
        searchResults.map((company) => (
          <Card id={company.symbol} key={uuidv4()} searchResult={company} />
        ))
      ) : (
        <h1>No results found</h1>
      )}
    </>
  );
};

export default CardList;
