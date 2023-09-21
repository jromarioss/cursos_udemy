import { useContext } from "react"
import { CounterContext } from "../context/CounterContext";
import { useCounterContext } from '../hooks/useCounterContext'
import { useTitleContext } from '../hooks/useTitleContext'

export const Home = () => {
  //const { counter } = useContext(CounterContext);
  const { counter } = useCounterContext();
  const { color, dispatch } = useTitleContext();

  const setTitleColor = (color) => {
    dispatch({ type: color });
  }

  return (
    <div>
      <h1 style={{ color: color }}>Home</h1>
      <p>{counter}</p>

      <div>
        <button onClick={() => setTitleColor('RED')}>red</button>
        <button onClick={() => setTitleColor('BLUE')}>blue</button>
      </div>
    </div>
  )
}