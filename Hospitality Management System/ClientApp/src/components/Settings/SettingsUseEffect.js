import axios from "axios";

export const fetchUserData = async (setFormData) => {
  try {
    const token = localStorage.getItem("token");
    const response = await axios.get("api/auth/settings", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    const userData = response.data;
    setFormData({
      username: userData.username || "",
      email: userData.email || "",
      emailDomain: userData.email.includes("@")
        ? "@" + userData.email.split("@")[1]
        : "",
      role: userData.role || "Patient",
      passwordHash: userData.passwordHash || "",
    });
  } catch (error) {
    console.error("Error fetching user data:", error);
  }
};
