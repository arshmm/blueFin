import React, { useCallback, useEffect, useState } from "react";
import StockCommentForm from "./StockCommentForm/StockCommentForm";
import { commentGetAPI, commentPostAPI } from "../../Services/CommentService";
import { toast } from "react-toastify";
import { CommentGet } from "../../Models/Comment";
import Spinner from "../Spinners/Spinner";
import StockCommentList from "../StockCommentList/StockCommentList";
import { useOutletContext } from "react-router-dom";

type Props = {};

type CommentFormInputs = {
  title: string;
  content: string;
};

const StockComment = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [comments, setComment] = useState<CommentGet[] | null>(null);
  const [loading, setLoading] = useState<boolean>();

  const getComments = useCallback(() => {
    setLoading(true);
    commentGetAPI(ticker).then((res) => {
      setLoading(false);
      setComment(res?.data!);
    });
  }, [ticker]);

  useEffect(() => {
    getComments();
  }, [getComments]);

  const handleComment = (e: CommentFormInputs) => {
    commentPostAPI(e.title, e.content, ticker)
      .then((res) => {
        if (res) {
          toast.success("Comment created successfully!");
          getComments();
        }
      })
      .catch((e) => {
        toast.warning(e);
      });
  };

  return (
    <section className="mt-6 w-full space-y-4">
      <div className="flex items-baseline justify-between">
        <h2 className="text-xs font-semibold uppercase tracking-wider text-slate-500">
          Discussion
        </h2>
        {comments && comments.length > 0 && (
          <span className="text-xs text-slate-500">
            {comments.length} {comments.length === 1 ? "comment" : "comments"}
          </span>
        )}
      </div>
      <StockCommentForm symbol={ticker} handleComment={handleComment} />
      {loading ? <Spinner /> : <StockCommentList comments={comments!} />}
    </section>
  );
};

export default StockComment;
