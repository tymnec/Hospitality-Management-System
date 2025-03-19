import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import SettingsUiComponents from "./SettingsUiComponents";
import useSettingsFormState from "./SettingsFormState";

const Settings = () => {
  const {
    formData,
    setFormData,
    handleChange,
    handleSubmit,
    generateRandomUsername,
    handleEmailDomainChange,
    isFormValid,
  } = useSettingsFormState();

  return (
    <div className="container mt-5">
      <SettingsUiComponents
        formData={formData}
        setFormData={setFormData}
        handleChange={handleChange}
        handleSubmit={handleSubmit}
        generateRandomUsername={generateRandomUsername}
        handleEmailDomainChange={handleEmailDomainChange}
        isFormValid={isFormValid}
      />
    </div>
  );
};

export default Settings;
