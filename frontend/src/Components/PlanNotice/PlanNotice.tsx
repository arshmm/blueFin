import React from "react";

type Props = {
  ticker: string;
};

const PlanNotice = ({ ticker }: Props) => {
  return (
    <div className="w-full px-4">
      <div className="max-w-xl mx-auto mt-10 p-5 rounded-xl border border-amber-500/30 bg-amber-500/10 text-amber-200 shadow-lg shadow-black/20 text-center">
        <p className="font-medium">
          Financial data for {ticker.toUpperCase()} isn't available on the
          free plan.
        </p>
        <p className="text-sm mt-2 text-amber-200/70">Try AAPL, MSFT or TSLA.</p>
      </div>
    </div>
  );
};

export default PlanNotice;
