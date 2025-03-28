import React, { useState, useEffect } from "react";
import "./Sidebar.css";
import {
  FaDashcube,
  FaUserInjured,
  FaUserMd,
  FaCalendarCheck,
  FaFileInvoiceDollar,
  FaAngleDoubleRight,
  FaAngleDoubleLeft,
} from "react-icons/fa";

const Sidebar = () => {
  const [isCollapsed, setIsCollapsed] = useState(
    sessionStorage.getItem("isCollapsed") === "true"
  );

  useEffect(() => {
    sessionStorage.setItem("isCollapsed", isCollapsed);
  }, [isCollapsed]);

  const handleCollapse = () => {
    setIsCollapsed(!isCollapsed);
  };

  const handleLinkClick = (path) => {
    window.location.href = path;
  };

  return isCollapsed ? (
    <CollapseSidebar
      onCollapse={handleCollapse}
      handleLinkClick={handleLinkClick}
    />
  ) : (
    <ExpandedSidebar
      onExpand={handleCollapse}
      handleLinkClick={handleLinkClick}
    />
  );
};
const CollapseSidebar = ({ onCollapse, handleLinkClick }) => {
  return (
    <div
      className="d-flex flex-column p-3 bg-light sticky-top"
      style={{
        backdropFilter: "blur(5px)",
        backgroundImage: "linear-gradient(to top,rgb(161, 189, 218), white)",
        height: "100vh",
      }}
    >
      <button className="d-block p-3 link-dark text-decoration-none bg-transparent border-0">
        <i className="bi-bootstrap fs-1"></i>
      </button>
      <nav className="nav nav-pills flex-column">
        <button
          className="btn btn-light py-3 px-2 bg-transparent border-0"
          onClick={() => handleLinkClick("/dashboard")}
        >
          <FaDashcube />
        </button>
        <button
          className="btn btn-light py-3 px-2 bg-transparent border-0"
          onClick={() => handleLinkClick("/patients")}
        >
          <FaUserInjured />
        </button>
        <button
          className="btn btn-light py-3 px-2 bg-transparent border-0"
          onClick={() => handleLinkClick("/doctors")}
        >
          <FaUserMd />
        </button>
        <button
          className="btn btn-light py-3 px-2 bg-transparent border-0"
          onClick={() => handleLinkClick("/appointments")}
        >
          <FaCalendarCheck />
        </button>
        <button
          className="btn btn-light py-3 px-2 bg-transparent border-0"
          onClick={() => handleLinkClick("/billing")}
        >
          <FaFileInvoiceDollar />
        </button>
      </nav>
      <button
        className="btn btn-light btn-primary mt-auto"
        onClick={onCollapse}
      >
        <FaAngleDoubleRight />
      </button>
    </div>
  );
};
const ExpandedSidebar = ({ onExpand, handleLinkClick }) => {
  return (
    <div
      className="d-flex flex-column p-3 bg-light sticky-top"
      style={{
        position: "relative",
        top: 0,
        left: 0,
        height: "100vh",
        width: "250px",
        background: "#333",
        padding: "20px",
        transition: "all 0.5s",
        zIndex: 1,
        backgroundColor: "white",
      }}
    >
      <div className="sidebar-wrapper">
        <img
          style={{
            backgroundImage:
              "url('https://img.freepik.com/free-vector/family-with-baby-visiting-doctor_1262-19778.jpg?semt=ais_hybrid')",
            backgroundSize: "cover",
            backgroundPosition: "center",
            width: "100%",
            height: "100%",
            top: 0,
            left: 0,
            zIndex: -1,
          }}
          className="img-fluid rounded-3"
        ></img>
        <div className="sidebar-menu d-flex flex-column mt-3">
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2 d-flex align-items-center"
            onClick={() => handleLinkClick("/dashboard")}
          >
            <FaDashcube className="me-2" />
            <span>Dashboard</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2 d-flex align-items-center"
            onClick={() => handleLinkClick("/patients")}
          >
            <FaUserInjured className="me-2" />
            <span>Patients</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2 d-flex align-items-center"
            onClick={() => handleLinkClick("/doctors")}
          >
            <FaUserMd className="me-2" />
            <span>Doctors</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2 d-flex align-items-center"
            onClick={() => handleLinkClick("/appointments")}
          >
            <FaCalendarCheck className="me-2" />
            <span>Appointments</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2 d-flex align-items-center"
            onClick={() => handleLinkClick("/billing")}
          >
            <FaFileInvoiceDollar className="me-2" />
            <span>Billing</span>
          </button>
        </div>
        <button type="button" className="btn btn-secondary" onClick={onExpand}>
          <FaAngleDoubleLeft />
        </button>
      </div>
    </div>
  );
};

export default Sidebar;
