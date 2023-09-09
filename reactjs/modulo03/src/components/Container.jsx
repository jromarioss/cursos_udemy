export function Container({children, myValue}) {
  return(
    <div>
      <h2>Esse é o título do container</h2>
      {children}
      <p>meu valor é {myValue}</p>
    </div>
  )
}