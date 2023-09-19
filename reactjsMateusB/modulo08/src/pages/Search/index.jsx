import { useSearchParams, Link } from "react-router-dom";

import { useFetch } from "../../hooks/useFetch";

export const Search = () => {
  const [searchParams] = useSearchParams();

  const url = "http://localhosto:3333/products?"+searchParams;

  const { data, loading } = useFetch(url);

  return (
    <div>
      <h2>Search</h2>

      {data && data.map(item => {
          return (
            <li key={item.id}>
              <h2>{item.name}</h2>
              <p>R$: {item.price}</p>
              <Link to={`/products/${item.id}`}>Detalhes</Link>
            </li>
          )
        })}
    </div>
  )
}