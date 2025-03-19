// Generates a random username by creating a random string and prefixing it with 'user_'
export const generateRandomUsername = () => {
  const randomString = Math.random().toString(36).substring(2, 10); // Generate a random string
  return `user_${randomString}`; // Prefix with 'user_'
};

// Validates the form by checking if all values are non-empty and role is not 'Patient'
export const isFormValid = (formData) => {
  if (!formData) return false; // Ensure formData is not null or undefined
  return Object.values(formData).every(
    (value) => value !== "" && value !== "Patient" // Validate each value
  );
};

// Handles changes to the email domain input and updates the email field accordingly
export const handleEmailDomainChange = (e, setFormData, formData) => {
  setFormData({
    ...formData,
    emailDomain: e.target.value, // Update email domain
    email: formData.email.split("@")[0] + e.target.value, // Combine email name with the new domain
  });
};

// Handles general input changes and updates the corresponding field in the form data
export const handleChange = (e, setFormData, formData) => {
  const { name, value } = e.target; // Get the name and value of the input field
  setFormData({
    ...formData,
    [name]: value, // Update the corresponding form field
  });
};
