import { Link } from 'react-router-dom'

import { useFetch } from '../../hooks/useFetch'

import './styles.css'

export const Home = () => {
  const url = 'http://localhost:3333/products';
  const { data , loading} = useFetch(url);
  return (
    <div>
      <h1>Produtos</h1>
      <ul className='products'>
        {data && data.map(item => {
          return (
            <li key={item.id}>
              <h2>{item.name}</h2>
              <p>R$: {item.price}</p>
              <Link to={`/products/${item.id}`}>Detalhes</Link>
            </li>
          )
        })}
      </ul>
    </div>
  )
}