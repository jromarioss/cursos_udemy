import { NavLink } from "react-router-dom"

import styled from "./Navbar.module.css";

export const Navbar = () => {
  return (
    <div className={styled.navbar}>
      <NavLink to="/">
        Mini <span>Blog</span>
      </NavLink>
      
      <ul>
        <li><NavLink to="/">Home</NavLink></li>
        <li><NavLink to="/about">About</NavLink></li>
      </ul>
    </div>
  )
}