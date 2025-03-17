# Hospitality Management System

## Project Overview

The **Hospitality Management System** is a web application designed to streamline hospital operations, manage patient records, appointments, and billing. It provides a user-friendly interface for doctors, patients, and hospital staff.

## Tech Stack

- **Frontend:** ReactJS, Bootstrap (Located in `ClientApp` folder)
- **Backend:** ASP.NET (Located in `Hospitality Management System` folder)
- **Database:** MongoDB
- **Containerization:** Docker (Compose file included)

## Project Structure

```
.
├── compose.yaml                # Docker Compose configuration
├── Docs
│   └── README.md               # Documentation files
├── global.json                 # .NET global settings
├── Hospitality Management System
│   ├── appsettings.Development.json  # Development settings
│   ├── appsettings.json        # Application settings
│   ├── bin                     # Compiled binaries
│   ├── ClientApp               # Frontend ReactJS application
│   ├── Controllers             # API Controllers
│   ├── Dockerfile              # Docker image setup
│   ├── Hospitality Management System.csproj # .NET project file
│   ├── obj                     # Compiled object files
│   ├── Pages                   # Razor pages (if applicable)
│   ├── Program.cs              # Main entry point
│   ├── Properties              # Project properties
│   └── WeatherForecast.cs       # Sample API model
└── Hospitality Management System.sln  # Solution file
```

## Features

- **Patient Management**: Add, update, and delete patient records.
- **Doctor Management**: Assign doctors, view schedules, and manage appointments.
- **Appointment Booking**: Patients can book and track their appointments.
- **Billing System**: Generate invoices and manage payments.
- **Authentication & Authorization**: Secure login for patients, doctors, and admin.
- **Docker Support**: Easily deployable using Docker Compose.

## Installation

### Prerequisites

Ensure you have the following installed:

- Node.js & npm
- .NET SDK
- MongoDB
- Docker (Optional for containerized setup)

### Steps

1. **Clone the Repository**

   ```sh
   git clone https://github.com/your-repo/hospitality-management-system.git
   cd hospitality-management-system
   ```

2. **Setup Backend**

   ```sh
   cd "Hospitality Management System"
   dotnet restore
   dotnet run
   ```

3. **Setup Frontend**

   ```sh
   cd ClientApp
   npm install
   npm start
   ```

4. **Start MongoDB** (Ensure MongoDB service is running)

5. **Run with Docker (Optional)**
   ```sh
   docker-compose up --build
   ```

## API Endpoints

| Method | Endpoint          | Description                  |
| ------ | ----------------- | ---------------------------- |
| GET    | /api/patients     | Fetch all patients           |
| POST   | /api/patients     | Add a new patient            |
| GET    | /api/doctors      | Fetch all doctors            |
| POST   | /api/appointments | Create a new appointment     |
| GET    | /api/billing      | Retrieve billing information |

## Contributing

1. Fork the repository.
2. Create a new branch: `git checkout -b feature-branch`.
3. Commit your changes: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature-branch`.
5. Open a pull request.

## License

This project is licensed under the MIT License.

## Contact

For any queries, reach out to **your-email@example.com**.
