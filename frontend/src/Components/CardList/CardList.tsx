import Card from "../Card/Card";

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
      <Card companyName="Apple Inc." ticker="AAPL" price={110.0} />
      <Card companyName="Microsoft Corporation" ticker="MSFT" price={200.0} />
      <Card companyName="Google LLC" ticker="GOOGL" price={150.0} />
    </div>
  );
};

export default CardList;
