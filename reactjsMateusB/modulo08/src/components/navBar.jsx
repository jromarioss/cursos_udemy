import { Link } from 'react-router-dom';

import './navBar.css';

export const NavBar = () => {
  return (
    <nav>
      <Link to='/' >Home</Link>
      <Link to='/about' >About</Link>
    </nav>
  )
}