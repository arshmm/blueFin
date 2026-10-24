import { useState } from "react";
import { PortfolioGet } from "../../../Models/Portfolio";
import { formatCurrency } from "../../../Util/numberFormatting";

interface Props {
  holdings: PortfolioGet[];
}

type Slice = { name: string; value: number; color: string };
type GroupBy = "holding" | "industry";

// Categorical palette validated for CVD separation and contrast on slate-900
const SERIES_COLORS = [
  "#3987e5",
  "#d95926",
  "#199e70",
  "#c98500",
  "#d55181",
  "#008300",
  "#9085e9",
  "#e66767",
];
const OTHER_COLOR = "#64748b";

const buildSlices = (holdings: PortfolioGet[], groupBy: GroupBy): Slice[] => {
  // Keep portfolio order so each entity keeps its color as values move
  const totals = new Map<string, number>();
  for (const h of holdings) {
    if (!h.marketValue || h.marketValue <= 0) continue;
    const key = groupBy === "holding" ? h.symbol : h.industry || "Unknown";
    totals.set(key, (totals.get(key) ?? 0) + h.marketValue);
  }
  const entries = Array.from(totals.entries());

  if (entries.length <= SERIES_COLORS.length) {
    return entries.map(([name, value], i) => ({
      name,
      value,
      color: SERIES_COLORS[i],
    }));
  }

  // More than 8: keep the 7 largest, fold the rest into "Other"
  const keep = new Set(
    [...entries]
      .sort((a, b) => b[1] - a[1])
      .slice(0, SERIES_COLORS.length - 1)
      .map(([name]) => name),
  );
  const slices: Slice[] = entries
    .filter(([name]) => keep.has(name))
    .map(([name, value], i) => ({ name, value, color: SERIES_COLORS[i] }));
  const otherValue = entries
    .filter(([name]) => !keep.has(name))
    .reduce((sum, [, value]) => sum + value, 0);
  slices.push({ name: "Other", value: otherValue, color: OTHER_COLOR });
  return slices;
};

const AllocationChart = ({ holdings }: Props) => {
  const [groupBy, setGroupBy] = useState<GroupBy>("holding");
  const [hovered, setHovered] = useState<number | null>(null);

  const slices = buildSlices(holdings, groupBy);
  const total = slices.reduce((sum, s) => sum + s.value, 0);

  if (total <= 0) {
    return null;
  }

  const percent = (value: number) => (value / total) * 100;

  // Left offset of each segment's center, for placing the tooltip
  let running = 0;
  const centers = slices.map((s) => {
    const center = running + percent(s.value) / 2;
    running += percent(s.value);
    return center;
  });

  const tabClass = (active: boolean) =>
    `rounded-md px-3 py-1 text-xs font-semibold transition ${
      active
        ? "bg-slate-700 text-slate-100"
        : "text-slate-400 hover:text-slate-200"
    }`;

  return (
    <div className="mb-8 rounded-xl border border-slate-800 bg-slate-900 p-5 shadow-lg shadow-black/20">
      <div className="mb-4 flex items-center justify-between gap-4">
        <h3 className="text-sm font-semibold text-slate-100">Allocation</h3>
        <div
          className="flex gap-1 rounded-lg bg-slate-800/60 p-1"
          role="tablist"
        >
          <button
            role="tab"
            aria-selected={groupBy === "holding"}
            className={tabClass(groupBy === "holding")}
            onClick={() => setGroupBy("holding")}
          >
            By holding
          </button>
          <button
            role="tab"
            aria-selected={groupBy === "industry"}
            className={tabClass(groupBy === "industry")}
            onClick={() => setGroupBy("industry")}
          >
            By industry
          </button>
        </div>
      </div>

      <div className="relative">
        <div
          className="flex h-6 items-center gap-[2px]"
          role="img"
          aria-label={
            "Allocation: " +
            slices
              .map((s) => `${s.name} ${percent(s.value).toFixed(1)}%`)
              .join(", ")
          }
          onMouseLeave={() => setHovered(null)}
        >
          {slices.map((s, i) => (
            <div
              key={s.name}
              className="flex h-full cursor-default items-center"
              style={{ width: `${percent(s.value)}%`, minWidth: 4 }}
              onMouseEnter={() => setHovered(i)}
            >
              <div
                className={`h-3.5 w-full transition-opacity ${
                  i === 0 ? "rounded-l" : ""
                } ${i === slices.length - 1 ? "rounded-r" : ""} ${
                  hovered !== null && hovered !== i ? "opacity-40" : ""
                }`}
                style={{ backgroundColor: s.color }}
              />
            </div>
          ))}
        </div>
        {hovered !== null && (
          <div
            className="pointer-events-none absolute bottom-full z-10 mb-2 -translate-x-1/2 whitespace-nowrap rounded-lg border border-slate-700 bg-slate-950 px-3 py-2 text-xs shadow-xl"
            style={{
              left: `${Math.min(Math.max(centers[hovered], 10), 90)}%`,
            }}
          >
            <div className="flex items-center gap-2 font-semibold text-slate-100">
              <span
                className="inline-block h-2.5 w-2.5 rounded-sm"
                style={{ backgroundColor: slices[hovered].color }}
              />
              {slices[hovered].name}
            </div>
            <div className="mt-0.5 tabular-nums text-slate-400">
              {formatCurrency(slices[hovered].value)} ·{" "}
              {percent(slices[hovered].value).toFixed(1)}%
            </div>
          </div>
        )}
      </div>

      <ul className="mt-4 flex flex-wrap gap-x-6 gap-y-2">
        {slices.map((s, i) => (
          <li
            key={s.name}
            className="flex items-center gap-2 text-sm"
            onMouseEnter={() => setHovered(i)}
            onMouseLeave={() => setHovered(null)}
          >
            <span
              className="inline-block h-2.5 w-2.5 shrink-0 rounded-sm"
              style={{ backgroundColor: s.color }}
            />
            <span className="max-w-[14rem] truncate text-slate-200" title={s.name}>
              {s.name}
            </span>
            <span className="tabular-nums text-slate-400">
              {percent(s.value).toFixed(1)}%
            </span>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default AllocationChart;
