import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

import { Home } from "./pages/Home";
import { About } from "./pages/About";

import { Navbar } from "./components/Navbar";
import { Footer } from "./components/Footer";

import './App.css'

function App() {

  return (
    <div>
      <BrowserRouter>
        <Navbar />
        <div className="Container">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
          </Routes>
        </div>
        <Footer />
      </BrowserRouter>
    </div>
  )
}

export default App;