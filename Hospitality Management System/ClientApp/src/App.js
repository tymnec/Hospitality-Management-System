import React, { Component } from "react";
import { Route, Routes, Navigate } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import { Layout } from "./components/Layout";
import Login from "./components/Login";
import "./custom.css";
import { Home } from "./components/Home";

// PrivateRoute Component
const PrivateRoute = ({ children }) => {
  return localStorage.getItem("token") ? children : <Navigate to="/login" />;
};

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          {/* You can manually define routes for login and dashboard if needed */}
          <Route path="/login" element={<Login />} />
          {/* Private route for dashboard
          <Route
            path="/dashboard"
            element={
              <PrivateRoute>
                <Home />
              </PrivateRoute>
            }
          /> */}
          {/* Add additional dynamic routes using AppRoutes */}
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}
