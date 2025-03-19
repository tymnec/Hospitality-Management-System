import axios from "axios";

export const fetchUserData = async (setFormData) => {
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
