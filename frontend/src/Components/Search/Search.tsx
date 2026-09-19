import { ChangeEvent, useState, SyntheticEvent } from "react";

interface Props {
  handleChange: (e: ChangeEvent<HTMLInputElement, HTMLInputElement>) => void;
  onClick: (e: SyntheticEvent) => void;
  search: string | undefined;
}

const Search = ({ handleChange, onClick, search }: Props) => {
  return (
    <div>
      <input
        type="text"
        placeholder="Search..."
        value={search}
        onChange={(e) => handleChange(e)}
      />
      <button onClick={(e) => onClick(e)}>Search</button>
    </div>
  );
};

export default Search;
