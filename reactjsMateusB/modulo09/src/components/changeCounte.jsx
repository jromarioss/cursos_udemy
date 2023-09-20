import { useContext } from "react"

import { CounterContext } from '../context/CounterContext';

export const changeCounte = () => {
  const {counter, setCounter} = useContext(CounterContext);

  return (
    <div>
      <button onClick={() => setCounter(counter + 1)}>add value to count</button>
    </div>
  )
}