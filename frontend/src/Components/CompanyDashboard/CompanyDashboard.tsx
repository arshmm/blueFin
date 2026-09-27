import React from "react";

import { Outlet } from "react-router-dom";

interface Props {
  children: React.ReactNode;
  ticker: string;
}

const CompanyDashboard = ({ children, ticker }: Props) => {
  return (
    <div className="relative md:ml-64 w-full min-h-screen">
      <div className="relative pt-8 pb-16">
        <div className="px-4 md:px-8 mx-auto w-full">
          <div>
            {children && <div className="flex flex-wrap">{children}</div>}
            <div className="mt-8 flex flex-wrap px-4">
              <Outlet context={ticker} />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CompanyDashboard;
