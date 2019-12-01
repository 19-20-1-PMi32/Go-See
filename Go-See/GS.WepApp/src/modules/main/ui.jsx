import React from "react";
import { Layout, Menu } from "antd";
import PropTypes from "prop-types";

const { Header, Content } = Layout;

const City = ({ city }) => (
  <Layout>
    <Header className="header">
      <div className="logo" />
      <Menu
        theme="dark"
        mode="horizontal"
        defaultSelectedKeys={["2"]}
        style={{ lineHeight: "64px" }}
      >
        <Menu.Item key="1">nav 1</Menu.Item>
        <Menu.Item key="2">nav 2</Menu.Item>
        <Menu.Item key="3">nav 3</Menu.Item>
      </Menu>
    </Header>
    <Layout style={{ padding: "0 24px 24px" }}>
      <Content
        style={{
          background: "#fff",
          padding: 24,
          margin: 0,
          minHeight: 280
        }}
      >
        {`Content: ${city}`}
      </Content>
    </Layout>
  </Layout>
);

City.propTypes = {
  city: PropTypes.shape({}).isRequired
};

export default City;
