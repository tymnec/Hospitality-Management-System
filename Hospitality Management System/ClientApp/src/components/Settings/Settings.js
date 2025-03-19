import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css"; // Import Bootstrap CSS
import { GiPerspectiveDiceSixFacesRandom } from "react-icons/gi";
import { AiOutlineMail } from "react-icons/ai"; // Email Icon
import axios from "axios"; // Import axios for API requests

const Settings = () => {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    emailDomain: "", // Added emailDomain to handle domain selection
    passwordHash: "",
    role: "Patient", // Default role as "Patient"
  });

  // Fetch user data from the backend
  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const token = localStorage.getItem("token"); // Get token from local storage
        const response = await axios.get("api/auth/settings", {
          headers: {
            Authorization: `Bearer ${token}`, // Include token in header
          },
        });
        // Populate the form with the fetched data
        const userData = response.data;
        setFormData({
          username: userData.username || "",
          email: userData.email || "",
          emailDomain: userData.email.split("@")[1] || "",
          role: userData.role || "Patient",
          passwordHash: userData.passwordHash || "",
        });
      } catch (error) {
        console.error("Error fetching user data:", error);
      }
    };

    fetchUserData();
  }, []);

  // Function to generate a random username
  const generateRandomUsername = () => {
    const randomString = Math.random().toString(36).substring(2, 10); // Generate a random string
    setFormData({
      ...formData,
      username: `user_${randomString}`, // Prefix with 'user_'
    });
  };

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({
      ...formData,
      [name]: type === "checkbox" ? checked : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("User settings updated:", formData);
    // Example: send formData to the backend to update user details
  };

  // Function to check if at least one field is filled (excluding the 'role' field)
  const isFormValid = () => {
    return Object.values(formData).some(
      (value) => value !== "" && value !== "Patient"
    );
  };

  // Handle email domain selection change
  const handleEmailDomainChange = (e) => {
    setFormData({
      ...formData,
      emailDomain: e.target.value,
      email: formData.email.split("@")[0] + e.target.value, // Combine email with domain
    });
  };

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h3>User Settings</h3>
        </div>
        <div className="card-body">
          <form onSubmit={handleSubmit}>
            {/* Username with Random Icon */}
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="username" className="form-label w-25">
                Username
              </label>
              <button
                type="button"
                className="btn btn-primary"
                onClick={generateRandomUsername}
                title="Generate Random Username"
              >
                <GiPerspectiveDiceSixFacesRandom size={"1.5em"} />
              </button>
              <input
                type="text"
                className="form-control ms-2"
                id="username"
                name="username"
                value={formData.username}
                onChange={handleChange}
                placeholder="Enter your username"
              />
            </div>

            {/* Email with Icon and Dropdown for domain selection */}
            <div className="mb-3 d-flex flex-column flex-md-row align-items-md-center">
              <div className="d-flex align-items-center mb-2 mb-md-0">
                <AiOutlineMail size={"1.5em"} className="me-2" />
                <label htmlFor="email" className="form-label w-100 w-md-25">
                  Email
                </label>
              </div>
              <input
                type="email"
                className="form-control mb-2 mb-md-0"
                id="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                placeholder="Enter your email"
              />

              {/* Email Domain Dropdown */}
              <div className="d-flex align-items-center">
                <label htmlFor="emailDomain" className="form-label me-2">
                  Email Domain
                </label>
                <select
                  className="form-select"
                  id="emailDomain"
                  name="emailDomain"
                  value={formData.emailDomain}
                  onChange={handleEmailDomainChange}
                >
                  <option value="">Select domain</option>
                  <option value="@gmail.com">Gmail</option>
                  <option value="@outlook.com">Outlook</option>
                  <option value="@yahoo.com">Yahoo</option>
                  <option value="@hotmail.com">Hotmail</option>
                  <option value="@aol.com">AOL</option>
                </select>
              </div>
            </div>

            {/* Password */}
            <div className="mb-3">
              <label htmlFor="password" className="form-label">
                Password
              </label>
              <input
                type="password"
                className="form-control"
                id="password"
                name="password"
                value={formData.passwordHash}
                onChange={handleChange}
                placeholder="Enter a new password"
              />
            </div>

            {/* Role */}
            <div className="mb-3">
              <label htmlFor="role" className="form-label">
                Role
              </label>
              <select
                className="form-select"
                id="role"
                name="role"
                value={formData.role}
                onChange={handleChange}
              >
                <option value="Patient">Patient</option>
                <option value="Admin">Admin</option>
                <option value="Staff">Staff</option>
              </select>
            </div>

            <button
              type="submit"
              className="btn btn-primary w-100"
              disabled={!isFormValid()} // Disable if no field is filled
            >
              Save Settings
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Settings;
