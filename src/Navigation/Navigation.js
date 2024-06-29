import React from 'react';
import { NavLink } from 'react-router-dom';

const Navigation = () => {
  return(
    <nav>
    <ul>
      <li><NavLink to="/" exact>Home</NavLink></li>
      <li><NavLink to="/login">Login/Register</NavLink></li>
      <li><NavLink to="/admin">Admin</NavLink></li>
      <li><NavLink to="/manager">Manager</NavLink></li>
      <li><NavLink to="/employee">Employee</NavLink></li>
      <li><NavLink to="/customer">Customer</NavLink></li>
    </ul>
    </nav>
  );
}



export default Navigation;