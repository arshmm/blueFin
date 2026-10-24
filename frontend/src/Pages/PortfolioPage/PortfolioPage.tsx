import { SyntheticEvent, useCallback, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { FaPen } from "react-icons/fa";
import { PortfolioGet, PortfolioPut } from "../../Models/Portfolio";
import {
  portfolioDeleteAPI,
  portfolioGetAPI,
  portfolioUpdateAPI,
} from "../../Services/PortfolioService";
import Table from "../../Components/Table/Table";
import Spinner from "../../Components/Spinners/Spinner";
import DeletePortfolio from "../../Components/Portfolio/DeletePortfolio/DeletePortfolio";
import EditPortfolio from "../../Components/Portfolio/EditPortfolio/EditPortfolio";
import AllocationChart from "../../Components/Portfolio/AllocationChart/AllocationChart";
import PortfolioSummary, {
  changeArrow,
  changeClass,
} from "../../Components/Portfolio/PortfolioSummary/PortfolioSummary";
import {
  formatCurrency,
  formatSignedCurrency,
  formatSignedPercent,
} from "../../Util/numberFormatting";

interface Props {}

const PortfolioPage = (props: Props) => {
  const [portfolio, setPortfolio] = useState<PortfolioGet[] | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [editing, setEditing] = useState<PortfolioGet | null>(null);

  useEffect(() => {
    getPortfolio();
  }, []);

  const getPortfolio = () => {
    portfolioGetAPI()
      .then((res) => {
        if (res?.data) {
          setPortfolio(res?.data);
        }
      })
      .catch((e) => {
        setPortfolio(null);
      })
      .finally(() => setLoading(false));
  };

  const onPortfolioDelete = (e: SyntheticEvent) => {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const symbol = formData.get("symbol") as string;
    portfolioDeleteAPI(symbol).then((res) => {
      if (res?.status === 204) {
        toast.success("Stock deleted from portfolio!");
        getPortfolio();
      }
    });
  };

  const onPortfolioUpdate = (symbol: string, update: PortfolioPut) => {
    portfolioUpdateAPI(symbol, update).then((res) => {
      if (res?.status === 200) {
        toast.success(`${symbol} updated!`);
        setEditing(null);
        getPortfolio();
      }
    });
  };

  const closeEdit = useCallback(() => setEditing(null), []);

  const config = [
    {
      label: "Holding",
      render: (stock: PortfolioGet) => (
        <div>
          <Link
            to={`/company/${stock.symbol}/company-profile`}
            className="font-semibold text-lightBlue hover:text-lightBlue/80"
          >
            {stock.symbol}
          </Link>
          <div
            className="max-w-[12rem] truncate text-xs text-slate-500"
            title={stock.companyName}
          >
            {stock.companyName}
          </div>
        </div>
      ),
    },
    {
      label: "Shares",
      render: (stock: PortfolioGet) =>
        stock.shares > 0 ? (
          stock.shares.toLocaleString("en-US", { maximumFractionDigits: 4 })
        ) : (
          <button
            onClick={() => setEditing(stock)}
            className="text-xs font-semibold text-amber-300 hover:text-amber-200"
          >
            Set shares
          </button>
        ),
    },
    {
      label: "Avg cost",
      render: (stock: PortfolioGet) => formatCurrency(stock.avgCost),
    },
    {
      label: "Price",
      render: (stock: PortfolioGet) => (
        <div>
          <div>{formatCurrency(stock.price)}</div>
          <div className={`text-xs ${changeClass(stock.changePercentage)}`}>
            {changeArrow(stock.changePercentage)}
            {formatSignedPercent(stock.changePercentage)}
          </div>
        </div>
      ),
    },
    {
      label: "Market value",
      render: (stock: PortfolioGet) => formatCurrency(stock.marketValue),
    },
    {
      label: "Gain / loss",
      render: (stock: PortfolioGet) => (
        <div className={changeClass(stock.gainLoss)}>
          <div>{formatSignedCurrency(stock.gainLoss)}</div>
          <div className="text-xs">
            {changeArrow(stock.gainLoss)}
            {formatSignedPercent(stock.gainLossPercentage)}
          </div>
        </div>
      ),
    },
    {
      label: "",
      render: (stock: PortfolioGet) => (
        <div className="flex w-24 gap-2">
          <button
            onClick={() => setEditing(stock)}
            aria-label={`Edit ${stock.symbol}`}
            title={`Edit ${stock.symbol}`}
            className="flex flex-1 items-center justify-center rounded-lg border border-slate-600 bg-slate-800 py-2.5 text-slate-300 transition duration-200 hover:bg-slate-700 hover:text-white"
          >
            <FaPen />
          </button>
          <div className="flex-1">
            <DeletePortfolio
              portfolioValue={stock.symbol}
              onPortfolioDelete={onPortfolioDelete}
            />
          </div>
        </div>
      ),
    },
  ];

  return (
    <section className="mx-auto max-w-5xl px-6 pb-16 pt-10">
      <div className="mb-6 flex items-baseline justify-between">
        <h2 className="text-3xl font-bold tracking-tight text-white md:text-4xl">
          My Portfolio
        </h2>
        {portfolio && portfolio.length > 0 && (
          <span className="text-sm text-slate-500">
            {portfolio.length} {portfolio.length === 1 ? "stock" : "stocks"}
          </span>
        )}
      </div>
      {loading ? (
        <Spinner />
      ) : portfolio && portfolio.length > 0 ? (
        <>
          <PortfolioSummary holdings={portfolio} />
          <AllocationChart holdings={portfolio} />
          <Table config={config} data={portfolio} />
        </>
      ) : (
        <div className="rounded-xl border border-dashed border-slate-700 py-8 text-center">
          <h3 className="text-base font-medium text-slate-500">
            Your portfolio is empty.
          </h3>
          <Link
            to="/search"
            className="mt-2 inline-block text-sm text-lightBlue hover:text-lightBlue/80"
          >
            Search for stocks to add
          </Link>
        </div>
      )}
      {editing && (
        <EditPortfolio
          holding={editing}
          onSave={onPortfolioUpdate}
          onClose={closeEdit}
        />
      )}
    </section>
  );
};

export default PortfolioPage;
