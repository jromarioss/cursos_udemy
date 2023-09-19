import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom'

import { Home } from './pages/Home'
import { About } from './pages/About'
import { Info } from './pages/Info'
import { NotFound } from './pages/NotFound'
import { Products } from './pages/Products'
import { NavBar } from './components/navBar'

import './App.css'
import { SearchForm } from './components/searchForm'
import { Search } from './pages/Search'

function App() {
  return (
    <div className='App'>
      <h1>React Router Dom</h1>
      <BrowserRouter>
      <NavBar />
      <SearchForm />

      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/about' element={<About />} />

        <Route path='products/:id/info' element={<Info />} />
        <Route path='products/:id' element={<Products />} />
        <Route path='/company' element={<Navigate to='/' />} />
        <Route path='/search' element={<Search />} />
        <Route path='*' element={<NotFound />} />
      </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
