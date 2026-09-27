import React, { useEffect, useState } from "react";
import { CompanyKeyMetrics } from "../../company";
import { useOutletContext } from "react-router-dom";
import { getKeyMetrics } from "../../Util/api";
import RatioList from "../RatioList/RatioList";
import Spinner from "../Spinners/Spinner";
import { hasStatementData } from "../../Util/freePlan";
import PlanNotice from "../PlanNotice/PlanNotice";
import {
  formatLargeMonetaryNumber,
  formatRatio,
} from "../../Util/numberFormatting";

type Props = {};

const tableConfig = [
  {
    label: "Market Cap",
    render: (company: CompanyKeyMetrics) =>
      formatLargeMonetaryNumber(company.marketCap),
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) =>
      formatRatio(company.currentRatioTTM),
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) =>
      formatRatio(company.returnOnEquityTTM),
  },
  {
    label: "Current assets and liabilities",
    render: (company: CompanyKeyMetrics) =>
      formatLargeMonetaryNumber(company.workingCapitalTTM),
  },
  {
    label: "Graham Number",
    render: (company: CompanyKeyMetrics) =>
      formatLargeMonetaryNumber(company.grahamNumberTTM),
    subTitle:
      "The upper bound of the price range that a defensive investor should pay for a stock",
  },
];

const CompanyProfile = (props: Props) => {
  const ticker = useOutletContext<string>();

  const [companyData, setCompanyData] = useState<CompanyKeyMetrics>();
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setCompanyData(undefined);
    setError(null);
    const fetchCompanyKeyMetrics = async () => {
      if (ticker) {
        if (!hasStatementData(ticker)) {
          return;
        }
        const data = await getKeyMetrics(ticker);
        if (typeof data === "string") {
          setError(data);
          return;
        }
        if (data.data.length === 0) {
          setError(`No key metrics found for ${ticker}.`);
          return;
        }
        setCompanyData(data.data[0]);
      }
    };

    fetchCompanyKeyMetrics();
  }, [ticker]);
  if (!hasStatementData(ticker)) return <PlanNotice ticker={ticker} />;
  return (
    <>
      {error ? (
        <p className="w-full rounded-xl border border-red-500/30 bg-red-500/10 px-4 py-3 my-4 font-medium text-red-300">
          {error}
        </p>
      ) : companyData ? (
        <RatioList data={companyData} config={tableConfig} />
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default CompanyProfile;
