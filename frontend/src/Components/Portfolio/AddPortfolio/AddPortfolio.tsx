import { SyntheticEvent } from "react";

interface Props {
  onPortfolioCreate: (e: SyntheticEvent) => void;
  symbol: string;
}

const AddPortfolio = ({ onPortfolioCreate, symbol }: Props) => {
  return (
    <div className="flex flex-col items-center justify-end flex-1 space-x-4 space-y-2 md:flex-row md:space-y-0">
      <form onSubmit={onPortfolioCreate}>
        <input readOnly={true} hidden={true} value={symbol} name="symbol" />
        <button
          type="submit"
          className="rounded-lg bg-lightBlue px-6 py-2 text-sm font-semibold text-white shadow-lg shadow-lightBlue/20 transition hover:brightness-110 focus:outline-none focus:ring-2 focus:ring-lightBlue/40"
        >
          Add
        </button>
      </form>
    </div>
  );
};

export default AddPortfolio;
