import { SyntheticEvent } from "react";
import { FaTrashAlt } from "react-icons/fa";

interface Props {
  onPortfolioDelete: (e: SyntheticEvent) => void;
  portfolioValue: string;
}

const DeletePortfolio = ({ onPortfolioDelete, portfolioValue }: Props) => {
  return (
    <div>
      <form onSubmit={onPortfolioDelete}>
        <input
          readOnly={true}
          hidden={true}
          value={portfolioValue}
          name="symbol"
        />
        <button
          aria-label={`Remove ${portfolioValue}`}
          title={`Remove ${portfolioValue}`}
          className="flex w-full items-center justify-center py-2.5 text-red-300 transition duration-200 border rounded-lg border-red-500/40 bg-red-500/10 hover:bg-red-500 hover:text-white"
        >
          <FaTrashAlt />
        </button>
      </form>
    </div>
  );
};

export default DeletePortfolio;
