import React from "react";

interface Props {
  data: any;
  config: any;
}

const RatioList = ({ data, config }: Props) => {
  const renderRow = config.map((item: any, index: number) => {
    return (
      <li className="py-3 sm:py-4" key={index}>
        <div className="flex items-center space-x-4">
          <div className="flex-1 min-w-0">
            <p className="text-sm font-medium text-slate-200 truncate">
              {item.label}
            </p>
            <p className="text-sm text-slate-500 truncate">{item.subTitle}</p>
          </div>
          <div className="inline-flex items-center text-base font-semibold tabular-nums text-slate-100">
            {item.render(data)}
          </div>
        </div>
      </li>
    );
  });
  return (
    <div className="w-full rounded-xl border border-slate-800 bg-slate-900 shadow-lg shadow-black/20 mb-4 p-4 sm:p-6 h-full">
      <ul className="divide-y divide-slate-800">{renderRow}</ul>
    </div>
  );
};

export default RatioList;
