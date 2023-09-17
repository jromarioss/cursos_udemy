import { useEffect, useState } from 'react'

import { useFetch } from "./hooks/useFetch"

import './App.css'

const url = "http://localhost:3333/products";

function App() {
  const { data, httpConfig, loading } = useFetch(url);

  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  
  const handleSubmit = async(e) => {
    e.preventDefault();

    const product = { name, price };
    httpConfig(product, "POST");

    setName("");
    setPrice("");
  }

  return (
    <div className='App'>
      <h1>lista de produtos</h1>
      <div className='addProduct'>
        <form onSubmit={handleSubmit}>
          <label> Name:
            <input type="text" value={name} name="name" onChange={(e) => setName(e.target.value)} />
          </label>

          <label> Preço $:
            <input type="number" value={price} name="price" onChange={(e) => setPrice(e.target.value)} />
          </label>

          {loading ?
            <input type="submit" value="salvando" disabled />
            :
            <input type="submit" value="enviar" />
          }
        </form>
      </div>
      {loading ?
        <p>Carregando</p>
        :
        <ul>
          {data && data.map((products) => {
            return (
              <li key={products.id}>{products.name} - R$: {products.price}</li>
            )
          })}
        </ul>
      }
      
    </div>
  )
}

export default App
