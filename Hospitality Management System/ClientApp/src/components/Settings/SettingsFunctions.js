export const generateRandomUsername = () => {
  const randomString = Math.random().toString(36).substring(2, 10);
  return `user_${randomString}`;
};

export const isFormValid = (formData) => {
  if (!formData) return false;
  return Object.values(formData).every(
    (value) => value !== "" && value !== "Patient"
  );
};

export const handleEmailDomainChange = (e, setFormData, formData) => {
  setFormData({
    ...formData,
    emailDomain: e.target.value,
    email: formData.email.split("@")[0] + e.target.value,
  });
};

export const handleChange = (e, setFormData, formData) => {
  const { name, value } = e.target;
  setFormData({
    ...formData,
    [name]: value,
  });
};
