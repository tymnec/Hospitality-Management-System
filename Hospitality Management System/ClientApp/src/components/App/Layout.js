import React from "react";
import { Container } from "reactstrap";
import NavMenu from "../Fixed/NavigationBar/NavMenu";
import Sidebar from "../Canvas/Sidebar/Sidebar";
import Overview from "../Dynamic/OverviewTabs/Overview";

const Layout = ({ children }) => {
  return (
    <div style={{ display: "flex" }}>
      <Sidebar />
      <div style={{ flex: 1 }}>
        <NavMenu />
        <Overview />
        <Container>{children}</Container>
      </div>
    </div>
  );
};

export default Layout;
