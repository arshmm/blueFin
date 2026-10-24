import { PortfolioGet } from "../../../Models/Portfolio";
import {
  formatCurrency,
  formatSignedCurrency,
  formatSignedPercent,
} from "../../../Util/numberFormatting";

interface Props {
  holdings: PortfolioGet[];
}

// Green/red with an arrow and sign, so gains never rely on color alone
export const changeClass = (value: number | null) =>
  value === null || value === 0
    ? "text-slate-400"
    : value > 0
      ? "text-emerald-400"
      : "text-red-400";

export const changeArrow = (value: number | null) =>
  value === null || value === 0 ? "" : value > 0 ? "▲ " : "▼ ";

const StatTile = ({
  label,
  value,
  detail,
  detailClass = "text-slate-400",
}: {
  label: string;
  value: string;
  detail?: string;
  detailClass?: string;
}) => (
  <div className="rounded-xl border border-slate-800 bg-slate-900 p-5 shadow-lg shadow-black/20">
    <h5 className="mb-1 text-xs font-semibold uppercase tracking-wider text-slate-500">
      {label}
    </h5>
    <p className="truncate text-2xl font-semibold tabular-nums text-slate-100">
      {value}
    </p>
    {detail && (
      <p className={`mt-1 truncate text-sm tabular-nums ${detailClass}`}>
        {detail}
      </p>
    )}
  </div>
);

const PortfolioSummary = ({ holdings }: Props) => {
  const priced = holdings.filter((h) => h.marketValue !== null);
  const totalValue = priced.reduce((sum, h) => sum + h.marketValue!, 0);
  const totalCost = priced.reduce((sum, h) => sum + h.costBasis, 0);
  const totalGain = totalValue - totalCost;
  const totalGainPct = totalCost > 0 ? (totalGain / totalCost) * 100 : null;

  const dayChange = priced.reduce((sum, h) => sum + (h.dayChange ?? 0), 0);
  const previousValue = totalValue - dayChange;
  const dayChangePct =
    previousValue > 0 ? (dayChange / previousValue) * 100 : null;

  const ranked = priced
    .filter((h) => h.gainLossPercentage !== null && h.shares > 0)
    .sort((a, b) => b.gainLossPercentage! - a.gainLossPercentage!);
  const best = ranked[0];
  const worst = ranked.length > 1 ? ranked[ranked.length - 1] : undefined;

  const missing = holdings.length - priced.length;

  return (
    <div className="mb-8">
      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-4">
        <StatTile
          label="Total value"
          value={formatCurrency(totalValue)}
          detail={`Cost ${formatCurrency(totalCost)}`}
        />
        <StatTile
          label="Total gain / loss"
          value={formatSignedCurrency(totalGain)}
          detail={changeArrow(totalGain) + formatSignedPercent(totalGainPct)}
          detailClass={changeClass(totalGain)}
        />
        <StatTile
          label="Today"
          value={formatSignedCurrency(dayChange)}
          detail={changeArrow(dayChange) + formatSignedPercent(dayChangePct)}
          detailClass={changeClass(dayChange)}
        />
        <StatTile
          label="Best / worst"
          value={best ? best.symbol : "N/A"}
          detail={
            best
              ? `${formatSignedPercent(best.gainLossPercentage)}` +
                (worst
                  ? ` · ${worst.symbol} ${formatSignedPercent(worst.gainLossPercentage)}`
                  : "")
              : undefined
          }
        />
      </div>
      {missing > 0 && (
        <p className="mt-3 text-sm text-amber-300">
          {missing} {missing === 1 ? "holding has" : "holdings have"} no live
          price and {missing === 1 ? "is" : "are"} left out of the totals.
        </p>
      )}
    </div>
  );
};

export default PortfolioSummary;
