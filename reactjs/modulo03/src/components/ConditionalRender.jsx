import { useState } from "react"

const ConditionalRender = () => {
  const [x] = useState(false)

  return (
    <div>
      <h1>Isso será exibido?</h1>
      {x && // condicional simples
        <p>Sim</p>
      }

      {x ? // condicional múltipla
        <p>Sim</p>
        :
        <p>Não</p>
      }
    </div>
  )
}

export default ConditionalRender