import React, { useEffect, useState } from "react";
import CompFinderItem from "./CompFinderItem/CompFinderItem";
import { CompanyCompData } from "../../company";
import { getCompData } from "../../Util/api";
import { isUsSymbol } from "../../Util/freePlan";
type Props = {
  ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyCompData[]>();
  useEffect(() => {
    setCompanyData(undefined);
    const getComps = async () => {
      const value = await getCompData(ticker);
      if (typeof value === "string") {
        console.error(value);
        return;
      }
      setCompanyData(value.data.filter((peer) => isUsSymbol(peer.symbol)));
    };
    getComps();
  }, [ticker]);
  if (companyData?.length === 0) {
    return (
      <p className="m-4 text-sm text-slate-500">
        No comparable US stocks found.
      </p>
    );
  }
  return (
    <div className="flex flex-wrap gap-2 m-4" role="group">
      {companyData?.map((peer) => {
        return <CompFinderItem key={peer.symbol} ticker={peer.symbol} />;
      })}
    </div>
  );
};

export default CompFinder;
