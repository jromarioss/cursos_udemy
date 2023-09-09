// arquivo de estilo

import MyComponent from "./MyComponent"

const FirstComponents = () => {
  // essa função faz isso
  return(
    <div>
      {/* Comentário no componente */}
      <h1>Meu primeiro Componente</h1>
      <p className="teste">Meu texto</p>
      <MyComponent />
    </div>
  )
}

export default FirstComponents