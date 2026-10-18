import React from "react";
import { CommentGet } from "../../Models/Comment";

type Props = {
  comment: CommentGet;
};

const StockCommentListItem = ({ comment }: Props) => {
  const initial = comment.createdBy ? comment.createdBy[0].toUpperCase() : "?";
  const date = comment.createdOn
    ? new Date(comment.createdOn).toLocaleDateString(undefined, {
        year: "numeric",
        month: "short",
        day: "numeric",
      })
    : "";

  return (
    <li className="flex gap-4 rounded-xl border border-slate-800 bg-slate-900 p-4 shadow-lg shadow-black/20 transition hover:border-slate-700 sm:p-5">
      <div className="flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-lightBlue/15 font-semibold text-lightBlue">
        {initial}
      </div>
      <div className="min-w-0 flex-1">
        <div className="flex flex-wrap items-baseline gap-x-2 text-sm">
          <span className="font-medium text-slate-200">
            @{comment.createdBy}
          </span>
          {date && <span className="text-slate-500">· {date}</span>}
        </div>
        <p className="mt-1 truncate font-semibold text-slate-100">
          {comment.title}
        </p>
        <p className="mt-1 whitespace-pre-line break-words text-[15px] leading-6 text-slate-300">
          {comment.content}
        </p>
      </div>
    </li>
  );
};

export default StockCommentListItem;
