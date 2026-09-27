import hero from "./hero.svg";
import "./Hero.css";
import { Link } from "react-router-dom";

interface Props {}

const Hero = (props: Props) => {
  return (
    <section id="hero" className="relative overflow-hidden">
      <div className="pointer-events-none absolute -top-40 left-1/2 h-[32rem] w-[32rem] -translate-x-1/2 rounded-full bg-lightBlue/20 blur-3xl" />
      <div className="pointer-events-none absolute bottom-0 right-0 h-80 w-80 rounded-full bg-lightGreen/10 blur-3xl" />
      <div className="container relative mx-auto flex flex-col-reverse items-center p-8 lg:flex-row">
        <div className="m-10 mb-44 flex flex-col space-y-8 lg:m-10 lg:mt-16 lg:w-1/2 xl:m-20 xl:mb-52">
          <h1 className="text-center text-5xl font-bold leading-tight tracking-tight text-white lg:max-w-md lg:text-left lg:text-6xl">
            Financial data with{" "}
            <span className="bg-gradient-to-r from-lightBlue to-lightGreen bg-clip-text text-transparent">
              no news.
            </span>
          </h1>
          <p className="text-center text-xl leading-relaxed text-slate-400 lg:max-w-md lg:text-left">
            Search relevant financial documents without fear mongering and fake
            news.
          </p>
          <div className="mx-auto lg:mx-0">
            <Link
              to="/search"
              className="inline-block rounded-xl bg-lightGreen px-10 py-4 text-xl font-semibold text-slate-950 shadow-xl shadow-lightGreen/20 transition hover:-translate-y-0.5 hover:brightness-110"
            >
              Get Started
            </Link>
          </div>
        </div>
        <div className="mx-auto mb-24 md:w-180 md:px-10 lg:mb-0 lg:w-1/2">
          <img src={hero} alt="" className="drop-shadow-2xl" />
        </div>
      </div>
    </section>
  );
};

export default Hero;
