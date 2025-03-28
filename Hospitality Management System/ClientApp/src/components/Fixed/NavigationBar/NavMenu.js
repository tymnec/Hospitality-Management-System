import React from "react";
import "./NavMenu.css";
import { FaGrinHearts, FaHome } from "react-icons/fa";
import { FaUserInjured } from "react-icons/fa";
import { FaUserMd } from "react-icons/fa";

const NavMenu = () => {
  const [width, setWidth] = React.useState(window.innerWidth);

  React.useEffect(() => {
    const handleResize = () => setWidth(window.innerWidth);
    window.addEventListener("resize", handleResize);
    return () => {
      window.removeEventListener("resize", handleResize);
    };
  });

  const handleNavigation = (path) => {
    window.location.href = path;
  };

  return width > 768 ? (
    <nav
      className="navbar navbar-expand-lg navbar-dark"
      style={{
        background: "linear-gradient(to right, white, rgb(128, 178, 229))",
      }}
    >
      <div className="container-fluid">
        <a className="navbar-brand" href="/">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="white"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
          >
            <rect x="3" y="3" width="18" height="18" rx="2" />
            <line x1="12" y1="3" x2="12" y2="21" />
          </svg>
        </a>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <button
                className="btn btn-primary bg-transparent border-0"
                onClick={() => handleNavigation("/")}
              >
                <FaHome className="me-2" />
                Home
              </button>
            </li>
            <li className="nav-item">
              <button
                className="btn btn-primary bg-transparent border-0"
                onClick={() => handleNavigation("/patients")}
              >
                <FaUserInjured className="me-2" />
                Patients
              </button>
            </li>
            <li className="nav-item">
              <button
                className="btn btn-primary bg-transparent border-0"
                onClick={() => handleNavigation("/settings")}
              >
                <FaUserMd className="me-2" />
                Settings
              </button>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  ) : null;
};

export default NavMenu;
