import { useContext } from "react"
import { CounterContext } from "../context/CounterContext";
import { useCounterContext } from '../hooks/useCounterContext'

export const Home = () => {
  //const { counter } = useContext(CounterContext);
  const { counter } = useCounterContext();

  return (
    <div>
      <h1>Home</h1>
      <p>{counter}</p>
    </div>
  )
}