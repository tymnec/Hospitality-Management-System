import React from "react";
import SuperAdminCard from "./SuperAdminCard";
import StatsCard from "./StatsCard";
import DoctorsList from "./DoctorsList";
import "./Dashboard.css";

const Dashboard = () => {
  const availableDoctors = [
    { name: "Smith", specialty: "Cardiology" },
    { name: "Johnson", specialty: "Neurology" },
    { name: "Williams", specialty: "Orthopedics" },
  ];

  return (
    <div className="dashboard">
      <SuperAdminCard />
      <StatsCard appointments={120} doctors={availableDoctors.length} />
      <DoctorsList doctors={availableDoctors} />
    </div>
  );
};

export default Dashboard;