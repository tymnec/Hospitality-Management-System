from selenium import webdriver
from selenium.webdriver.common.by import By
import time

def test_routing():
    # Set up WebDriver (Ensure you have the correct WebDriver installed, e.g., chromedriver, geckodriver)
    driver = webdriver.Chrome()  # Use "webdriver.Firefox()" if testing in Firefox
    driver.get("http://localhost:44482")  # Make sure your React app is running
    
    time.sleep(2)  # Wait for the page to load
    
    # Define routes to test
    routes = [
        ("/", "Home"),
        ("/login", "Login"),
        ("/dashboard", "Dashboard"),
        ("/patients", "Patients"),
        ("/doctors", "Doctors"),
        ("/appointments", "Appointments"),
        ("/billing", "Billing"),
    ]
    
    for path, page_name in routes:
        driver.get(f"http://localhost:44482{path}")
        time.sleep(2)  # Allow time for navigation
        
        if driver.title:
            print(f"✅ Route {path} loaded successfully (Title: {driver.title})")
        else:
            print(f"❌ Route {path} failed to load")
    
    driver.quit()

if __name__ == "__main__":
    test_routing()
