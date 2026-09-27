import React, { useEffect, useState } from "react";
import { CompanyIncomeStatement } from "../../company";
import { useOutletContext } from "react-router-dom";
import { getIncomeStatement } from "../../Util/api";
import Table from "../Table/Table";
import Spinner from "../Spinners/Spinner";
import { hasStatementData } from "../../Util/freePlan";
import PlanNotice from "../PlanNotice/PlanNotice";
import {
  formatLargeMonetaryNumber,
  formatRatio,
} from "../../Util/numberFormatting";

type Props = {};

// The stable API doesn't return margin ratios, so they're calculated from revenue.
const ratio = (value: number, revenue: number) =>
  revenue ? formatRatio(value / revenue) : "N/A";

const configs = [
  {
    label: "Date",
    render: (company: CompanyIncomeStatement) => company.date,
  },
  {
    label: "Revenue",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.revenue),
  },
  {
    label: "Cost Of Revenue",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.costOfRevenue),
  },
  {
    label: "Depreciation",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.depreciationAndAmortization),
  },
  {
    label: "Operating Income",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.operatingIncome),
  },
  {
    label: "Income Before Taxes",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.incomeBeforeTax),
  },
  {
    label: "Net Income",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.netIncome),
  },
  {
    label: "Net Income Ratio",
    render: (company: CompanyIncomeStatement) =>
      ratio(company.netIncome, company.revenue),
  },
  {
    label: "Earnings Per Share",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.eps),
  },
  {
    label: "Earnings Per Diluted",
    render: (company: CompanyIncomeStatement) =>
      formatLargeMonetaryNumber(company.epsDiluted),
  },
  {
    label: "Gross Profit Ratio",
    render: (company: CompanyIncomeStatement) =>
      ratio(company.grossProfit, company.revenue),
  },
  {
    label: "Operating Income Ratio",
    render: (company: CompanyIncomeStatement) =>
      ratio(company.operatingIncome, company.revenue),
  },
  {
    label: "Income Before Taxes Ratio",
    render: (company: CompanyIncomeStatement) =>
      ratio(company.incomeBeforeTax, company.revenue),
  },
];

const IncomeStatement = (props: Props) => {
  const ticker = useOutletContext<string>();

  const [incomeStatementData, setIncomeStatementData] =
    useState<CompanyIncomeStatement[]>();
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setIncomeStatementData(undefined);
    setError(null);
    const fetchIncomeStatement = async () => {
      if (ticker) {
        if (!hasStatementData(ticker)) {
          return;
        }
        const data = await getIncomeStatement(ticker);
        if (typeof data === "string") {
          setError(data);
          return;
        }
        if (data.data.length === 0) {
          setError(`No income statement found for ${ticker}.`);
          return;
        }
        setIncomeStatementData(data.data);
      }
    };

    fetchIncomeStatement();
  }, [ticker]);
  if (!hasStatementData(ticker)) return <PlanNotice ticker={ticker} />;
  return (
    <>
      {error ? (
        <p className="w-full rounded-xl border border-red-500/30 bg-red-500/10 px-4 py-3 my-4 font-medium text-red-300">
          {error}
        </p>
      ) : incomeStatementData ? (
        <>
          <Table data={incomeStatementData} config={configs} />
        </>
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default IncomeStatement;
