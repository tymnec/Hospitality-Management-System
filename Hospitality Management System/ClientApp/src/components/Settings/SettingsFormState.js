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
  }, [setFormData]);

  return {
    formData,
    setFormData,
    handleChange,
    generateRandomUsername,
    handleEmailDomainChange,
    isFormValid,
  };
};

export default useSettingsFormState;
