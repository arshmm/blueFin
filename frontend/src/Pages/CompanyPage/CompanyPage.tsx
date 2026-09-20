import { useParams } from "react-router-dom";
import { CompanyProfile } from "../../company";
import { useEffect, useState } from "react";
import { getCompanyProfile } from "../../api";

interface Props {}

const CompanyPage = (props: Props) => {
  let { ticker } = useParams<{ ticker: string }>();
  const [company, setCompany] = useState<CompanyProfile>();

  useEffect(() => {
    const fetchCompanyProfile = async () => {
      console.log("Fetching company profile for ticker:", ticker);
      if (ticker) {
        console.log("Fetching company profile for ticker:", ticker);
        const data = await getCompanyProfile(ticker);

        if (typeof data === "string") {
          console.error(data);
          return;
        }
        console.log("Company profile data:", data.data[0]);
        setCompany(data.data[0]);
        console.log("Company state updated:", company);
      }
    };
    fetchCompanyProfile();
  }, []);

  return (
    <>
      {company ? (
        <div>{company.companyName}</div>
      ) : (
        <div>Company not found</div>
      )}
    </>
  );
};

export default CompanyPage;
