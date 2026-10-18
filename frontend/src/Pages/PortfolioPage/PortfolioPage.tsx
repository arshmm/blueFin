import { SyntheticEvent, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { PortfolioGet } from "../../Models/Portfolio";
import {
  portfolioDeleteAPI,
  portfolioGetAPI,
} from "../../Services/PortfolioService";
import Table from "../../Components/Table/Table";
import Spinner from "../../Components/Spinners/Spinner";
import DeletePortfolio from "../../Components/Portfolio/DeletePortfolio/DeletePortfolio";
import { formatLargeMonetaryNumber } from "../../Util/numberFormatting";

interface Props {}

const PortfolioPage = (props: Props) => {
  const [portfolio, setPortfolio] = useState<PortfolioGet[] | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

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

  const config = [
    {
      label: "Symbol",
      render: (stock: PortfolioGet) => (
        <Link
          to={`/company/${stock.symbol}/company-profile`}
          className="font-semibold text-lightBlue hover:text-lightBlue/80"
        >
          {stock.symbol}
        </Link>
      ),
    },
    {
      label: "Company",
      render: (stock: PortfolioGet) => stock.companyName,
    },
    {
      label: "Industry",
      render: (stock: PortfolioGet) => stock.industry,
    },
    {
      label: "Price",
      render: (stock: PortfolioGet) => "$" + stock.purchase.toFixed(2),
    },
    {
      label: "Dividend",
      render: (stock: PortfolioGet) => stock.lastDividend,
    },
    {
      label: "Market Cap",
      render: (stock: PortfolioGet) =>
        formatLargeMonetaryNumber(stock.marketCap),
    },
    {
      label: "",
      render: (stock: PortfolioGet) => (
        <div className="w-12">
          <DeletePortfolio
            portfolioValue={stock.symbol}
            onPortfolioDelete={onPortfolioDelete}
          />
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
        <Table config={config} data={portfolio} />
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
    </section>
  );
};

export default PortfolioPage;
