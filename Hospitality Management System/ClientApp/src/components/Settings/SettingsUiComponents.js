import React, { useState } from "react";
import { GiPerspectiveDiceSixFacesRandom } from "react-icons/gi";
import { AiOutlineMail } from "react-icons/ai";
import { GiEyelashes } from "react-icons/gi";
import { GiEyeball } from "react-icons/gi";

const SettingsUiComponents = ({
  formData,
  handleChange,
  handleSubmit,
  generateRandomUsername,
  handleEmailDomainChange,
  isFormValid,
}) => {
  const [showPassword, setShowPassword] = useState(false);

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h3>User Settings</h3>
        </div>
        <div className="card-body">
          <form onSubmit={handleSubmit}>
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

            <div className="mb-3 position-relative">
              <label htmlFor="password" className="form-label">
                Password
              </label>
              <input
                type={showPassword ? "text" : "password"}
                className="form-control"
                id="password"
                name="passwordHash"
                value={formData.passwordHash}
                onChange={handleChange}
                placeholder="Enter a new password"
              />
              <button
                type="button"
                className="btn btn-outline-secondary position-relative end-0 top-0 mt-3 me-3"
                onClick={() => setShowPassword(!showPassword)}
              >
                View Password
                {showPassword ? (
                  <GiEyeball className="me-1 ml-2" />
                ) : (
                  <GiEyelashes className="me-1 ml-2" />
                )}
              </button>
            </div>

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
              disabled={!isFormValid()}
            >
              Save Settings
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default SettingsUiComponents;
