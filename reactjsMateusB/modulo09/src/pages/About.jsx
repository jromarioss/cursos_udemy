import { useContext } from "react";

import { CounterContext } from "../context/CounterContext";

//import { useTitleColorContext } from "../hooks/useTitleColorContext";

export const About = () => {
  const { counter } = useContext(CounterContext);

  // 5 - contexto mais complexo
  const { color } = useTitleColorContext();

  return (
    <div>
      <h1 style={{ color: color }}>About</h1>
      //<p>Valor contador: {counter}</p>
    </div>
  );
};