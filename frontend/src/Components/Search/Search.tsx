import React, { ChangeEvent, SyntheticEvent, JSX } from "react";

interface Props {
  onSearchSubmit: (e: SyntheticEvent) => void;
  search: string | undefined;
  handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({
  onSearchSubmit,
  search,
  handleSearchChange,
}: Props): JSX.Element => {
  return (
    <section className="relative">
      <div className="max-w-4xl mx-auto px-6 pt-10 pb-6 space-y-6">
        <form
          className="form relative flex flex-col w-full p-6 space-y-4 rounded-2xl border border-slate-800 bg-gradient-to-br from-slate-900 to-slate-900/40 shadow-2xl shadow-lightBlue/5 md:flex-row md:space-y-0 md:space-x-3"
          onSubmit={onSearchSubmit}
        >
          <input
            className="flex-1 rounded-xl border border-slate-700 bg-slate-950 px-4 py-3 text-slate-100 placeholder-slate-500 transition focus:border-lightBlue focus:outline-none focus:ring-2 focus:ring-lightBlue/30"
            id="search-input"
            placeholder="Search companies"
            value={search}
            onChange={handleSearchChange}
          />
          <button
            type="submit"
            className="rounded-xl bg-lightGreen px-8 py-3 font-semibold text-slate-950 shadow-lg shadow-lightGreen/20 transition hover:brightness-110 focus:outline-none focus:ring-2 focus:ring-lightGreen/40"
          >
            Search
          </button>
        </form>
      </div>
    </section>
  );
};

export default Search;
