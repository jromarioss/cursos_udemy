import { Link, NavLink } from 'react-router-dom';

import './navBar.css';

export const NavBar = () => {
  return (
    <nav>
      <NavLink to='/' >Home</NavLink>
      <NavLink to='/about' >About</NavLink>
    </nav>
  )
}