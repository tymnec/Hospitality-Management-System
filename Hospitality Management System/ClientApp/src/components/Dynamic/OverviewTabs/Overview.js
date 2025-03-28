import React from "react";
import "./Overview.css";
import {
  TabContent,
  TabPane,
  Nav,
  NavItem,
  NavLink,
  Row,
  Col,
} from "reactstrap";

const Overview = () => {
  const [activeTab, setActiveTab] = React.useState("1");

  const toggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  return (
    <div className="overview">
      <h2>Overview</h2>
      <Nav tabs>
        <NavItem>
          <NavLink
            className={activeTab === "1" ? "active" : ""}
            onClick={() => {
              toggle("1");
            }}
          >
            Patients
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
            className={activeTab === "2" ? "active" : ""}
            onClick={() => {
              toggle("2");
            }}
          >
            Doctors
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
            className={activeTab === "3" ? "active" : ""}
            onClick={() => {
              toggle("3");
            }}
          >
            Appointments
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
            className={activeTab === "4" ? "active" : ""}
            onClick={() => {
              toggle("4");
            }}
          >
            Billing
          </NavLink>
        </NavItem>
      </Nav>
      <TabContent activeTab={activeTab}>
        <TabPane tabId="1">
          <Row>
            <Col sm="12">
              <h4>Patient Overview</h4>
              <p>
                This is the patient overview page for the hospitality management
                system. It provides a summary of the system's current state and
                allows the user to view detailed information about each patient.
              </p>
            </Col>
          </Row>
        </TabPane>
        <TabPane tabId="2">
          <Row>
            <Col sm="12">
              <h4>Doctor Overview</h4>
              <p>
                This is the doctor overview page for the hospitality management
                system. It provides a summary of the system's current state and
                allows the user to view detailed information about each doctor.
              </p>
            </Col>
          </Row>
        </TabPane>
        <TabPane tabId="3">
          <Row>
            <Col sm="12">
              <h4>Appointment Overview</h4>
              <p>
                This is the appointment overview page for the hospitality
                management system. It provides a summary of the system's current
                state and allows the user to view detailed information about
                each appointment.
              </p>
            </Col>
          </Row>
        </TabPane>
        <TabPane tabId="4">
          <Row>
            <Col sm="12">
              <h4>Billing Overview</h4>
              <p>
                This is the billing overview page for the hospitality management
                system. It provides a summary of the system's current state and
                allows the user to view detailed information about each billing
                record.
              </p>
            </Col>
          </Row>
        </TabPane>
      </TabContent>
    </div>
  );
};

export default Overview;
