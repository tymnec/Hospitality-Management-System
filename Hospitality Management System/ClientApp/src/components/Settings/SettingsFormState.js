import { useState, useEffect } from "react";
import axios from "axios";
import {
  handleChange,
  generateRandomUsername,
  handleEmailDomainChange,
  isFormValid,
} from "./SettingsFunctions";
import { fetchUserData } from "./SettingsUseEffect";

const useSettingsFormState = () => {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    emailDomain: "",
    passwordHash: "",
    role: "Patient",
  });

  useEffect(() => {
    fetchUserData(setFormData);
  }, []);

  /**
   * Handles the form submission event for updating user settings.
   * Prevents the default form submission behavior, validates the form data,
   * and sends a PUT request to update the settings if the form is valid.
   * Displays an alert if the form is not valid or if an error occurs during submission.
   *
   * @param {Event} e - The form submission event.
   */

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (isFormValid(formData)) {
      try {
        await axios.put("/api/auth/settings", formData, {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
          },
        });

        alert("Settings updated successfully!");
      } catch (error) {
        const errMsg = error.message ? error.message : "unknown error";
        console.error("Error submitting form:", errMsg);
        alert("Error submitting form!");
      }
    } else {
      alert("Form is not valid! Please check all fields and try again.");
    }
  };

  return {
    formData,
    setFormData,
    handleChange: (e) => handleChange(e, setFormData, formData),
    handleSubmit,
    generateRandomUsername: () =>
      setFormData({ ...formData, username: generateRandomUsername() }),
    handleEmailDomainChange: (e) =>
      handleEmailDomainChange(e, setFormData, formData),
    isFormValid: () => isFormValid(formData),
  };
};

export default useSettingsFormState;
