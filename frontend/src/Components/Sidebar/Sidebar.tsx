import React from "react";
import { NavLink } from "react-router-dom";
import {
  FaBalanceScale,
  FaBuilding,
  FaChartLine,
  FaMoneyBillWave,
} from "react-icons/fa";

type Props = {};

const linkClass = ({ isActive }: { isActive: boolean }) =>
  `flex items-center gap-3 rounded-lg px-3 py-2.5 text-sm font-medium transition-colors ${
    isActive
      ? "bg-lightBlue/15 text-lightBlue"
      : "text-slate-400 hover:bg-slate-800/60 hover:text-slate-100"
  }`;

const Sidebar = (props: Props) => {
  return (
    <nav className="absolute left-0 top-0 bottom-0 z-40 block w-64 -translate-x-full transform border-r border-slate-800 bg-slate-900/60 px-4 py-6 transition-all duration-300 ease-in-out md:translate-x-0">
      <button className="absolute top-1/2 -right-6 flex h-10 w-6 cursor-pointer items-center justify-center rounded-r border border-l-0 border-slate-800 bg-slate-900 text-xl leading-none text-slate-400 focus:outline-none md:hidden">
        <i className="fas fa-ellipsis-v"></i>
      </button>

      <div className="flex w-full flex-col space-y-1">
        <NavLink to="company-profile" className={linkClass}>
          <FaBuilding />
          <span>Company Profile</span>
        </NavLink>
        <NavLink to="income-statement" className={linkClass}>
          <FaChartLine />
          <span>Income Statement</span>
        </NavLink>
        <NavLink to="balance-sheet" className={linkClass}>
          <FaBalanceScale />
          <span>Balance Sheet</span>
        </NavLink>
        <NavLink to="cash-flow" className={linkClass}>
          <FaMoneyBillWave />
          <span>Cash Flow</span>
        </NavLink>
      </div>
    </nav>
  );
};

export default Sidebar;
