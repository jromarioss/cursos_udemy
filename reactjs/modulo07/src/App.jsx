import { useEffect, useState } from 'react'
import './App.css'

function App() {
  const [products, setProducts] = useState([]);
  const url = "http://localhost:3333/products";

  async function fetchData() {
    const res = await fetch(url)
    const data = await res.json();
    setProducts(data)
  }

  useEffect(() => {
    fetchData()
  },[])

  console.log(products)

  return (
    <div className='App'>
      <h1>lista de produtos</h1>
      <ul>
        {products.map((products) => {
          return (
            <li key={products.id}>{products.name} - R$: {products.price}</li>
          )
        })}
      </ul>
    </div>
  )
}

export default App
