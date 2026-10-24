import { SyntheticEvent, useEffect, useRef } from "react";
import { PortfolioGet, PortfolioPut } from "../../../Models/Portfolio";

interface Props {
  holding: PortfolioGet;
  onSave: (symbol: string, update: PortfolioPut) => void;
  onClose: () => void;
}

const inputClass =
  "w-full rounded-lg border border-slate-700 bg-slate-950 px-3 py-2 text-sm text-slate-100 placeholder-slate-500 focus:border-lightBlue focus:outline-none focus:ring-2 focus:ring-lightBlue/30";

const EditPortfolio = ({ holding, onSave, onClose }: Props) => {
  const sharesRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    sharesRef.current?.focus();
    const onKeyDown = (e: KeyboardEvent) => {
      if (e.key === "Escape") onClose();
    };
    window.addEventListener("keydown", onKeyDown);
    return () => window.removeEventListener("keydown", onKeyDown);
  }, [onClose]);

  const onSubmit = (e: SyntheticEvent) => {
    e.preventDefault();
    const formData = new FormData(e.target as HTMLFormElement);
    const purchasedOn = formData.get("purchasedOn") as string;
    onSave(holding.symbol, {
      shares: Number(formData.get("shares")),
      avgCost: Number(formData.get("avgCost")),
      purchasedOn: purchasedOn || null,
    });
  };

  return (
    <div
      className="fixed inset-0 z-50 flex items-center justify-center bg-black/60 px-4"
      onClick={onClose}
    >
      <div
        role="dialog"
        aria-modal="true"
        aria-labelledby="edit-holding-title"
        className="w-full max-w-sm rounded-xl border border-slate-800 bg-slate-900 p-6 shadow-2xl"
        onClick={(e) => e.stopPropagation()}
      >
        <h3
          id="edit-holding-title"
          className="text-lg font-semibold text-slate-100"
        >
          Edit {holding.symbol}
        </h3>
        <p className="mb-5 text-sm text-slate-500">{holding.companyName}</p>
        <form onSubmit={onSubmit} className="space-y-4">
          <label className="block text-sm text-slate-300">
            Shares
            <input
              ref={sharesRef}
              type="number"
              name="shares"
              min="0.0001"
              step="any"
              required
              defaultValue={holding.shares || ""}
              className={`mt-1 ${inputClass}`}
            />
            <span className="mt-1 block text-xs text-slate-500">
              Sold some? Lower the share count. Sold everything? Remove the
              holding instead.
            </span>
          </label>
          <label className="block text-sm text-slate-300">
            Average cost per share
            <input
              type="number"
              name="avgCost"
              min="0.01"
              step="any"
              required
              defaultValue={holding.avgCost || holding.price || ""}
              className={`mt-1 ${inputClass}`}
            />
          </label>
          <label className="block text-sm text-slate-300">
            Purchase date (optional)
            <input
              type="date"
              name="purchasedOn"
              defaultValue={holding.purchasedOn?.slice(0, 10) ?? ""}
              className={`mt-1 ${inputClass} [color-scheme:dark]`}
            />
          </label>
          <div className="flex justify-end gap-2 pt-2">
            <button
              type="button"
              onClick={onClose}
              className="rounded-lg px-4 py-2 text-sm font-semibold text-slate-300 transition hover:bg-slate-800"
            >
              Cancel
            </button>
            <button
              type="submit"
              className="rounded-lg bg-lightBlue px-5 py-2 text-sm font-semibold text-white shadow-lg shadow-lightBlue/20 transition hover:brightness-110 focus:outline-none focus:ring-2 focus:ring-lightBlue/40"
            >
              Save
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditPortfolio;
