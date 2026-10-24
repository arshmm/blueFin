import { SyntheticEvent } from "react";

interface Props {
  onPortfolioCreate: (e: SyntheticEvent) => void;
  symbol: string;
}

const inputClass =
  "w-24 rounded-lg border border-slate-700 bg-slate-950 px-3 py-2 text-sm text-slate-100 placeholder-slate-500 focus:border-lightBlue focus:outline-none focus:ring-2 focus:ring-lightBlue/30";

const AddPortfolio = ({ onPortfolioCreate, symbol }: Props) => {
  return (
    <div className="flex flex-1 justify-end md:flex-none">
      <form
        onSubmit={onPortfolioCreate}
        className="flex flex-wrap items-center justify-center gap-2 md:flex-nowrap"
      >
        <input readOnly={true} hidden={true} value={symbol} name="symbol" />
        <input
          type="number"
          name="shares"
          min="0.0001"
          step="any"
          required
          placeholder="Shares"
          aria-label={`Shares of ${symbol}`}
          className={inputClass}
        />
        <input
          type="number"
          name="avgCost"
          min="0.01"
          step="any"
          placeholder="Cost/sh"
          title="Leave empty to use the current market price"
          aria-label={`Average cost per share of ${symbol}`}
          className={inputClass}
        />
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
