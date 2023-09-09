import { MyComponents } from "./components/MyComponents"

import "./App.css"
import { Title } from "./components/Title"

function App() {
  const n  = 10

  const hasTitle = false

  return (
    <div>
      <h1>React com CSS</h1>

      <MyComponents />

      <p>paragrafo do App</p>

      <p style={{ color: "red", backgroundColor: "green", fontWeight: "bold" }}>paragrafo inline</p>

      <h2 style={n < 20 ?
        ({ color: "black", backgroundColor: "red" })
        :
        ({ color: "red", backgroundColor: "black" })
      }>Css dinâmico</h2>

      <h3 className={hasTitle ? "title" : "noTitle"}>Este título vai ter classe dinâmica</h3>

      <Title />
    </div>
  )
}

export default App
