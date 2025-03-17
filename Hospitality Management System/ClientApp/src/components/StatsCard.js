import React from "react";
import { FaUserMd, FaCalendarCheck } from "react-icons/fa";
import "./StatsCard.css";

const StatsCard = ({ appointments, doctors }) => {
  return (
    <div className="stats-card">
      <div className="stats-item">
        <FaCalendarCheck className="stats-icon" />
        <h3>Total Appointments</h3>
        <p>{appointments}</p>
      </div>
      <div className="divider"></div>
      <div className="stats-item">
        <FaUserMd className="stats-icon" />
        <h3>Available Doctors</h3>
        <p>{doctors}</p>
      </div>
    </div>
  );
};

export default StatsCard;

