import { useParams } from "react-router-dom";
import { CompanyProfile } from "../../company";
import { useEffect, useState } from "react";
import { getCompanyProfile } from "../../Util/api";
import Sidebar from "../../Components/Sidebar/Sidebar";
import CompanyDashboard from "../../Components/CompanyDashboard/CompanyDashboard";
import Tile from "../../Components/Tile/Tile";
import Spinner from "../../Components/Spinners/Spinner";
import CompFinder from "../../Components/CompFinder/CompFinder";
import { formatLargeMonetaryNumber } from "../../Util/numberFormatting";

interface Props {}

const CompanyPage = (props: Props) => {
  let { ticker } = useParams<{ ticker: string }>();
  const [company, setCompany] = useState<CompanyProfile>();
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setCompany(undefined);
    setError(null);
    const fetchCompanyProfile = async () => {
      if (ticker) {
        const data = await getCompanyProfile(ticker);

        if (typeof data === "string") {
          setError(data);
          return;
        }
        if (data.data.length === 0) {
          setError(`No profile found for ${ticker}.`);
          return;
        }
        console.log("Company profile data:", data.data[0]);
        setCompany(data.data[0]);
      }
    };
    fetchCompanyProfile();
  }, [ticker]);

  return (
    <>
      {error ? (
        <p className="mx-4 mt-16 max-w-xl rounded-xl border border-red-500/30 bg-red-500/10 px-5 py-4 text-center font-medium text-red-300 sm:mx-auto">
          {error}
        </p>
      ) : company ? (
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <Sidebar />
          <CompanyDashboard ticker={ticker!}>
            <Tile title="Company Name" subTitle={company.companyName} />
            <Tile
              title="Price"
              subTitle={formatLargeMonetaryNumber(company.price)}
            />
            <Tile title="Sector" subTitle={company.sector} />
            <Tile
              title="Market Cap"
              subTitle={formatLargeMonetaryNumber(company.marketCap)}
            />
            <CompFinder ticker={company.symbol} />
            <p className="mx-4 mt-2 basis-full rounded-xl border border-slate-800 border-l-4 border-l-lightBlue/70 bg-slate-900/60 px-6 py-5 text-[15px] leading-7 text-slate-300 shadow-lg shadow-black/20">
              {company.description}
            </p>
          </CompanyDashboard>
        </div>
      ) : (
        <Spinner />
      )}
    </>
  );
};

export default CompanyPage;
