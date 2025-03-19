import { useState, useEffect } from "react";
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

  const handleSubmit = (e) => {
    e.preventDefault();
    if (isFormValid(formData)) {
      fetch("/api/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      })
        .then((res) => res.json())
        .then((data) => {
          localStorage.setItem("token", data.token);
          window.location.href = "/dashboard";
        })
        .catch((error) => {
          console.error("Error submitting form:", error);
          alert("Error submitting form!");
        });
    } else {
      alert("Form is not valid!");
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
