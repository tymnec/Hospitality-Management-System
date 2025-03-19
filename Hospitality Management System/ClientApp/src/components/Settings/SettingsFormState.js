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
    fetchUserData(setFormData); // Make sure the function is receiving setFormData
  }, [setFormData]);

  return {
    formData,
    setFormData, // Return setFormData along with other functions
    handleChange,
    generateRandomUsername,
    handleEmailDomainChange,
    isFormValid,
  };
};

export default useSettingsFormState;
