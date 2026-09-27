import React, { useEffect, useState } from "react";
import { CompanyBalanceSheet } from "../../company";
import { useOutletContext } from "react-router-dom";
import { getBalanceSheetData } from "../../Util/api";
import RatioList from "../RatioList/RatioList";
import Spinner from "../Spinners/Spinner";
import { hasStatementData } from "../../Util/freePlan";
import PlanNotice from "../PlanNotice/PlanNotice";
import { formatLargeMonetaryNumber } from "../../Util/numberFormatting";

type Props = {};

const config = [
  {
    label: <span className="font-bold">Total Assets</span>,
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalAssets),
  },
  {
    label: "Current Assets",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalCurrentAssets),
  },
  {
    label: "Total Cash",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.cashAndCashEquivalents),
  },
  {
    label: "Property & Equipment",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.propertyPlantEquipmentNet),
  },
  {
    label: "Intangible Assets",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.intangibleAssets),
  },
  {
    label: <span className="font-bold">Total Liabilities</span>,
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalLiabilities),
  },
  {
    label: "Current Liabilities",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalCurrentLiabilities),
  },
  {
    label: "Long-Term Debt",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.longTermDebt),
  },
  {
    label: "Total Debt",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalDebt),
  },
  {
    label: "Long-Term Deferred Taxes",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.deferredTaxLiabilitiesNonCurrent),
  },
  {
    label: "Stockholders' Equity",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.totalStockholdersEquity),
  },
  {
    label: "Retained Earnings",
    render: (company: CompanyBalanceSheet) =>
      formatLargeMonetaryNumber(company.retainedEarnings),
  },
];

const BalanceSheet = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [balanceSheetData, setBalanceSheetData] =
    useState<CompanyBalanceSheet>();
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setBalanceSheetData(undefined);
    setError(null);
    const fetchBalanceSheetData = async () => {
      if (ticker) {
        if (!hasStatementData(ticker)) {
          return;
        }
        const data = await getBalanceSheetData(ticker);
        if (typeof data === "string") {
          setError(data);
          return;
        }
        if (data.data.length === 0) {
          setError(`No balance sheet found for ${ticker}.`);
          return;
        }
        setBalanceSheetData(data.data[0]);
      }
    };

    fetchBalanceSheetData();
  }, [ticker]);
  if (!hasStatementData(ticker)) return <PlanNotice ticker={ticker} />;
  return (
    <>
      {error ? (
        <p className="w-full rounded-xl border border-red-500/30 bg-red-500/10 px-4 py-3 my-4 font-medium text-red-300">
          {error}
        </p>
      ) : balanceSheetData ? (
        <RatioList data={balanceSheetData} config={config} />
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default BalanceSheet;
