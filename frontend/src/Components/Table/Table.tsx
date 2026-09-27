interface Props {
  config: any;
  data: any;
}

const Table = ({ config, data }: Props) => {
  const renderedRows = data.map((company: any, index: number) => {
    return (
      <tr
        key={index}
        className="transition-colors odd:bg-slate-900 even:bg-slate-900/40 hover:bg-slate-800/60"
      >
        {config.map((column: any) => {
          return (
            <td
              className="px-4 py-3 whitespace-nowrap text-sm font-normal tabular-nums text-slate-200"
              key={column.label}
            >
              {column.render(company)}
            </td>
          );
        })}
      </tr>
    );
  });
  const renderedHeaders = config.map((config: any) => {
    return (
      <th
        className="px-4 py-3 text-left text-xs font-semibold text-slate-400 uppercase tracking-wider whitespace-nowrap"
        key={config.label}
      >
        {config.label}
      </th>
    );
  });

  return (
    <div className="w-full overflow-x-auto rounded-xl border border-slate-800 bg-slate-900 shadow-lg shadow-black/20">
      <table className="min-w-full divide-y divide-slate-800">
        <thead className="bg-slate-800/60">
          <tr>{renderedHeaders}</tr>
        </thead>
        <tbody className="divide-y divide-slate-800/60">{renderedRows}</tbody>
      </table>
    </div>
  );
};

export default Table;
