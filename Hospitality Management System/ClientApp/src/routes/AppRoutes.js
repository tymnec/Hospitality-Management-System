// src/AppRoutes.js
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "../components/App/Home/Home.js";
import Login from "../components/Login";
import Dashboard from "../components/Dashboard";
import Patients from "../components/Patients";
import PatientDetails from "../components/PatientDetails";
import DoctorsList from "../components/DoctorsList";
import Appointments from "../components/Appointments";
import Billing from "../components/Billing";
import Layout from "../components/App/Layout"; // For Navbar & Sidebar
import NotFound from "../components/NotFound";

function AppRoutes() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/patients" element={<Patients />} />
          <Route path="/patients/:id" element={<PatientDetails />} />
          <Route path="/doctors" element={<DoctorsList />} />
          <Route path="/appointments" element={<Appointments />} />
          <Route path="/billing" element={<Billing />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default AppRoutes;
