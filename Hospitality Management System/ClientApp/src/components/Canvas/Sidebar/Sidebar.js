import React, { useState } from "react";
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
  const [isCollapsed, setIsCollapsed] = useState(false);

  const handleCollapse = () => {
    setIsCollapsed(!isCollapsed);
  };

  return isCollapsed ? (
    <CollapseSidebar onCollapse={handleCollapse} />
  ) : (
    <ExpandedSidebar onExpand={handleCollapse} />
  );
};

const CollapseSidebar = ({ onCollapse }) => {
  return (
    <div className="sidebar">
      <div className="sidebar-wrapper">
        <div className="sidebar-menu">
          <ul className="nav">
            <li className="nav-item">
              <a className="nav-link" href="/dashboard">
                <FaDashcube />
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/patients">
                <FaUserInjured />
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/doctors">
                <FaUserMd />
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/appointments">
                <FaCalendarCheck />
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/billing">
                <FaFileInvoiceDollar />
              </a>
            </li>
          </ul>
        </div>
        <button className="btn btn-primary btn-secondary" onClick={onCollapse}>
          <FaAngleDoubleRight />
        </button>
      </div>
    </div>
  );
};

const ExpandedSidebar = ({ onExpand }) => {
  return (
    <div className="sidebar">
      <div className="sidebar-wrapper">
        <img
          style={{
            backgroundImage:
              "url('https://img.freepik.com/free-vector/family-with-baby-visiting-doctor_1262-19778.jpg?semt=ais_hybrid')",
            backgroundSize: "cover",
            backgroundPosition: "center",
            width: "100%",
            height: "100%",
          }}
          className="img-fluid rounded-3"
        ></img>
        <div className="sidebar-menu d-flex flex-column mt-3">
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2"
            href="/dashboard"
          >
            <span>Dashboard</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2"
            href="/patients"
          >
            <span>Patients</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2"
            href="/doctors"
          >
            <span>Doctors</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2"
            href="/appointments"
          >
            <span>Appointments</span>
          </button>
          <button
            type="button"
            className="btn btn-light nav-link py-2 px-3 mb-2"
            href="/billing"
          >
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
