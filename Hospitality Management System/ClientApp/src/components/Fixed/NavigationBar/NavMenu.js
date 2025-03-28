import React from "react";
import "./NavMenu.css";

const NavMenu = () => {
  return (
    <nav className="navbar">
      <div className="logo">
        <a href="#">Logo</a>
      </div>
      <ul className="nav-links">
        <li>
          <a href="#">Home</a>
        </li>
        <li>
          <a href="#">About</a>
        </li>
        <li>
          <a href="#">Services</a>
        </li>
        <li>
          <a href="#">Contact</a>
        </li>
      </ul>
    </nav>
  );
};

export default NavMenu;
