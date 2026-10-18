import React from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";

type Props = {
  symbol: string;
  handleComment: (e: CommentFormInputs) => void;
};

type CommentFormInputs = {
  title: string;
  content: string;
};

const validation = Yup.object().shape({
  title: Yup.string().required("Title is required"),
  content: Yup.string().required("Content is required"),
});

const inputClass =
  "w-full rounded-xl border border-slate-700 bg-slate-950 px-4 py-3 text-sm text-slate-100 placeholder-slate-500 transition focus:border-lightBlue focus:outline-none focus:ring-2 focus:ring-lightBlue/30";

const StockCommentForm = ({ symbol, handleComment }: Props) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<CommentFormInputs>({ resolver: yupResolver(validation) });
  return (
    <form
      className="space-y-3 rounded-xl border border-slate-800 bg-slate-900 p-4 shadow-lg shadow-black/20 sm:p-5"
      onSubmit={handleSubmit(handleComment)}
    >
      <div>
        <label htmlFor="title" className="sr-only">
          Title
        </label>
        <input
          type="text"
          id="title"
          className={inputClass}
          placeholder="Title"
          {...register("title")}
        />
        {errors.title ? (
          <p className="mt-1 text-xs text-red-300">{errors.title.message}</p>
        ) : (
          ""
        )}
      </div>
      <div>
        <label htmlFor="comment" className="sr-only">
          Your comment
        </label>
        <textarea
          id="comment"
          rows={4}
          className={`${inputClass} resize-y`}
          placeholder={`What do you think about ${symbol}?`}
          {...register("content")}
        ></textarea>
        {errors.content ? (
          <p className="mt-1 text-xs text-red-300">{errors.content.message}</p>
        ) : (
          ""
        )}
      </div>
      <div className="flex justify-end">
        <button
          type="submit"
          className="rounded-xl bg-lightGreen px-5 py-2.5 text-sm font-semibold text-slate-950 shadow-lg shadow-lightGreen/20 transition hover:brightness-110 focus:outline-none focus:ring-2 focus:ring-lightGreen/40"
        >
          Post comment
        </button>
      </div>
    </form>
  );
};

export default StockCommentForm;
