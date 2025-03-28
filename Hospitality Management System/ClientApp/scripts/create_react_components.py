import os

def create_folder_structure(base_path):
    folders = [
        "src/components/Settings",
        "src/context",
        "src/hooks",
        "src/services",
        "src/routes",
        "src/styles"
    ]
    
    components = [
        "Counter.js", "Dashboard.css", "Dashboard.js", "DoctorsList.css", "DoctorsList.js",
        "FetchData.js", "Home.js", "Layout.js", "Login.js", "NavMenu.css", "NavMenu.js",
        "StatsCard.css", "StatsCard.js", "SuperAdminCard.css", "SuperAdminCard.js",
        "Patients.js", "PatientDetails.js", "Appointments.js", "Billing.js", "NotFound.js"
    ]
    
    component_template = """import React from 'react';

const {name} = () => {
    return <h1>{name} Page</h1>;
};

export default {name};
"""
    
    # Create directories
    for folder in folders:
        os.makedirs(os.path.join(base_path, folder), exist_ok=True)
    
    # Create missing component files
    for component in components:
        component_path = os.path.join(base_path, "src/components", component)
        if not os.path.exists(component_path):
            with open(component_path, 'w') as file:
                name = component.replace(".js", "")
                file.write(component_template.replace("{name}", name))
    
    print("Folder structure and components updated successfully!")

# Run script in the current directory
if __name__ == "__main__":
    # base_directory = os.path.dirname(os.path.abspath(__file__))  # Change this to the project root if needed
    base_directory = "/Users/nikhilsarwara/RiderProjects/Hospitality Management System/Hospitality Management System/ClientApp"
    create_folder_structure(base_directory)
