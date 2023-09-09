import { MyForms } from './components/MyForms'

function App() {

  return (
    <div>
      <h2>Forms</h2>

      <MyForms user={{ name: "José", email: "jose@email.com" }} />
    </div>
  )
}

export default App
