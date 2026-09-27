import React, { useEffect, useState } from "react";
import { CompanyCashFlow } from "../../company";
import { getCashFlowData } from "../../Util/api";
import { useOutletContext } from "react-router-dom";
import Table from "../Table/Table";
import Spinner from "../Spinners/Spinner";
import { hasStatementData } from "../../Util/freePlan";
import PlanNotice from "../PlanNotice/PlanNotice";
import { formatLargeMonetaryNumber } from "../../Util/numberFormatting";

const config = [
  {
    label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    label: "Operating Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.operatingCashFlow),
  },
  {
    label: "Investing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.netCashProvidedByInvestingActivities),
  },
  {
    label: "Financing Cashflow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.netCashProvidedByFinancingActivities),
  },
  {
    label: "Cash At End of Period",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.cashAtEndOfPeriod),
  },
  {
    label: "CapEX",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.capitalExpenditure),
  },
  {
    label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.commonStockIssuance),
  },
  {
    label: "Free Cash Flow",
    render: (company: CompanyCashFlow) =>
      formatLargeMonetaryNumber(company.freeCashFlow),
  },
];

const CashflowStatement = () => {
  const ticker = useOutletContext<string>();
  const [cashFlowData, setCashFlowData] = useState<CompanyCashFlow[]>();
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setCashFlowData(undefined);
    setError(null);
    const fetchCashFlowData = async () => {
      if (ticker) {
        if (!hasStatementData(ticker)) {
          return;
        }
        const data = await getCashFlowData(ticker);
        if (typeof data === "string") {
          setError(data);
          return;
        }
        if (data.data.length === 0) {
          setError(`No cash flow statement found for ${ticker}.`);
          return;
        }
        setCashFlowData(data.data);
      }
    };

    fetchCashFlowData();
  }, [ticker]);
  if (!hasStatementData(ticker)) return <PlanNotice ticker={ticker} />;
  return (
    <>
      {error ? (
        <p className="w-full rounded-xl border border-red-500/30 bg-red-500/10 px-4 py-3 my-4 font-medium text-red-300">
          {error}
        </p>
      ) : cashFlowData ? (
        <Table data={cashFlowData} config={config} />
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default CashflowStatement;
