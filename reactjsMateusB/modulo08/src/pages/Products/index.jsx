import { Link, useParams } from 'react-router-dom'

import { useFetch } from '../../hooks/useFetch'

export const Products = () => {
  const { id } = useParams();
  
  const url = `http://localhost:3333/products/${id}`;

  const { data, loading } = useFetch(url);

  return (
    <div>
      <p>Id do produto: {id}</p>
      {loading && <p>Carregando...</p>}
      {data &&
        <div>
          <h2>{data.name}</h2>
          <p>R$: {data.price}</p>
          <Link to={`/products/${data.id}/info`}>Mais informações</Link>
        </div>
      }
    </div>
  )
}