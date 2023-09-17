import { BrowserRouter, Route, Routes } from 'react-router-dom'

import { Home } from './pages/Home'
import { About } from './pages/About'
import { Products } from './pages/Products'
import { NavBar } from './components/navBar'

import './App.css'

function App() {
  return (
    <div className='App'>
      <h1>React Router Dom</h1>
      <BrowserRouter>
      <NavBar />
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/about' element={<About />} />

          <Route path='products/:id' element={<Products />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
