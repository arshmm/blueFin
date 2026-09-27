import React from "react";

interface Props {
  title: string;
  subTitle: string;
}

const Tile = ({ title, subTitle }: Props) => {
  return (
    <div className="w-full lg:w-6/12 xl:w-3/12 px-4 mb-6 xl:mb-0">
      <div className="relative flex h-32 flex-col min-w-0 break-words rounded-xl border border-slate-800 bg-slate-900 shadow-lg shadow-black/20 transition hover:border-slate-700">
        <div className="flex-auto p-5">
          <div className="flex flex-wrap">
            <div className="relative w-full pr-4 max-w-full flex-grow flex-1">
              <h5 className="mb-1 text-slate-500 uppercase font-semibold text-xs tracking-wider">
                {title}
              </h5>

              <span
                className="line-clamp-2 font-semibold text-xl leading-7 text-slate-100"
                title={subTitle}
              >
                {subTitle}
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Tile;
