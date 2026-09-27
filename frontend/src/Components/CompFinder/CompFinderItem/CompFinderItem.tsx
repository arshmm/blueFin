import React from "react";
import { Link } from "react-router-dom";

type Props = {
  ticker: string;
};

const CompFinderItem = ({ ticker }: Props) => {
  return (
    <Link
      reloadDocument
      to={`/company/${ticker}/company-profile`}
      type="button"
      className="inline-flex items-center rounded-full border border-slate-700 bg-slate-900 px-4 py-1.5 text-sm font-medium text-slate-300 transition hover:border-lightBlue/60 hover:bg-lightBlue/10 hover:text-lightBlue focus:outline-none focus:ring-2 focus:ring-lightBlue/40"
    >
      {ticker}
    </Link>
  );
};

export default CompFinderItem;
