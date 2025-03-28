### **Route Setup**

| Path            | Component        | Description                                           |
| --------------- | ---------------- | ----------------------------------------------------- |
| `/`             | `Home`           | Landing page with an overview/dashboard               |
| `/login`        | `Login`          | Authentication page for patients, doctors, and admins |
| `/dashboard`    | `Dashboard`      | Main dashboard with quick stats & links               |
| `/patients`     | `Patients`       | List of patients, add/update/delete records           |
| `/patients/:id` | `PatientDetails` | Detailed view of a specific patient                   |
| `/doctors`      | `Doctors`        | List of doctors, schedules, and assignments           |
| `/appointments` | `Appointments`   | Booking and tracking patient appointments             |
| `/billing`      | `Billing`        | Invoices and payment tracking                         |
