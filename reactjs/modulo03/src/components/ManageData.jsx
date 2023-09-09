import { useState } from "react";

const ManageData = () => {
  const [number, setNumber] = useState(0);

  return (
    <div>
      <p>O valor: {number}</p>
      <button onClick={() => setNumber(number + 1)}>Mudar valor</button>
    </div>
  )
}

export default ManageData