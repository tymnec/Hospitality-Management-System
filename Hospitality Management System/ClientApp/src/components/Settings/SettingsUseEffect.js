import axios from "axios";

export const fetchUserData = async (setFormData) => {
  const token = localStorage.getItem("token");
  if (!token || token === "undefined") {
    alert("You need to login first!");
    window.location.href = "/login";
    return;
  }

  try {
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
