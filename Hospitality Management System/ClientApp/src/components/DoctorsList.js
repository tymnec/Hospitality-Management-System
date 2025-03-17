import React from "react";
import "./DoctorsList.css";

const DoctorsList = ({ doctors }) => {
  return (
    <div className="doctors-list">
      {doctors.map((doctor, index) => (
        <div key={index} className="card doctor-card">
          <h4>Dr. {doctor.name}</h4>
          <p>Specialty: {doctor.specialty}</p>
        </div>
      ))}
    </div>
  );
};

export default DoctorsList;
