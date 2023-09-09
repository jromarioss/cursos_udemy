export function CarDetails({ brand, km, color, newCar }) {
  return(
    <div>
      <h2>Detalhes do carros</h2>

      <ul>
        <li>Marca: {brand}</li>
        <li>Km: {km}</li>
        <li>Cor: {color}</li>
      </ul>
      {newCar && <p>Este carro e novo</p>}
    </div>
  )
}