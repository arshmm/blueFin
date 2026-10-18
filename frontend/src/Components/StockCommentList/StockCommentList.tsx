import React from "react";
import { CommentGet } from "../../Models/Comment";
import StockCommentListItem from "../StockCommentListItem/StockCommentListItem";

type Props = {
  comments: CommentGet[];
};

const StockCommentList = ({ comments }: Props) => {
  if (!comments || comments.length === 0) {
    return (
      <p className="rounded-xl border border-dashed border-slate-800 px-4 py-8 text-center text-sm text-slate-500">
        No comments yet. Be the first to share your thoughts.
      </p>
    );
  }

  return (
    <ul className="space-y-3">
      {comments.map((comment) => (
        <StockCommentListItem key={comment.id} comment={comment} />
      ))}
    </ul>
  );
};

export default StockCommentList;
