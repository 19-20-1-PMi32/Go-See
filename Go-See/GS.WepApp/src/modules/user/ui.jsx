import React from "react";

import { Layout, Menu, Row, Col, Input, Dropdown, Avatar, Button, Icon } from "antd";
import { Link } from "react-router-dom";

import styles from "./index.scss";

const { Header, Content } = Layout;
const menu = (
  <Menu className={styles["dropdown-menu-items"]}>
    <Menu.Item key="1">Your Profile</Menu.Item>
    <Menu.Item key="2">Your Trips</Menu.Item>
    <Menu.Item key="3">Log out</Menu.Item>
  </Menu>
);


const UserPage = () => {
    return (
      <Layout>
        <Header className={styles["header-container"]}>
          <Row type="flex" justify="start" align="middle">
            <Col xs={4} sm={4} md={3} lg={2} xl={2}>
              <Link to="/">
                <img
                  className={styles["logo-img"]}
                  src="/src/assets/logo.png"
                  alt="Logo"
                />
              </Link>
            </Col>
            <Col
              xs={{ span: 14, offset: 6 }}
              sm={{ span: 14, offset: 4 }}
              md={{ span: 9, offset: 4 }}
              lg={{ span: 8, offset: 5 }}
              xl={{ span: 6, offset: 6 }}
            >
              <Input.Search
                placeholder="Search for attractions"
                onSearch={value => console.log(value)}
                className={styles["search-input"]}
              />
            </Col>
            <Col
              xs={{ span: 3, offset: 13 }}
              sm={{ span: 3, offset: 12 }}
              md={{ span: 2, offset: 4 }}
              lg={{ span: 2, offset: 4 }}
              xl={{ span: 2, offset: 5 }}
            >
              <Dropdown overlay={menu} placement="bottomCenter" trigger={["click"]}>
                <a href="# ">
                  <Avatar
                    icon="user"
                    size="large"
                    className={styles["user-icon"]}
                  />
                </a>
              </Dropdown>
            </Col>
            <Col
              xs={{ span: 4, offset: 2 }}
              sm={{ span: 3, offset: 0 }}
              md={{ span: 2, offset: 0 }}
              lg={{ span: 2, offset: 0 }}
              xl={{ span: 2, offset: 0 }}
            >
              <div className={styles["lang-curr"]}>
                <span>EN</span>
                <span>UAH</span>
              </div>
            </Col>
          </Row>
        </Header>
        <Layout>
          <Content className={styles["content-bg"]}>
            <div className={styles["main-contant"]}>
              <div style={{marginTop: 60}}>
                <Button className={styles["button-user"]}>Edit info</Button>
                <Row
                  type="flex"
                  justify="center"             
                  className={styles["user-info"]}
                >
                  <Col
                    xs={{ span: 10, offset: 3 }}
                    sm={{ span: 6, offset: 2 }}
                    md={{ span: 4, offset: 1 }}
                    lg={{ span: 5, offset: 1 }}
                    xl={{ span: 5, offset: 1 }}
                  >
                    <a href="# ">
                      <Avatar
                        icon="user"
                        size={120}
                        className={styles["user-icon"]}
                      />
                    </a>
                  </Col>
                  <Col
                    xs={{ span: 14, offset: 5 }}
                    sm={{ span: 10, offset: 3 }}
                    md={{ span: 8, offset: 1 }}
                    lg={{ span: 7, offset: 1 }}
                    xl={{ span: 6, offset: 1 }}
                    className={styles["user-data"]}
                  >
                    <div>
                      <h2>FirstName LastName</h2>
                      <p 
                        style={{fontSize: 17, lineHeight: 0}}
                      >
                        UserName
                      </p>
                    </div>
                    <div>
                      <div className={styles["phone-number"]}>
                        <Icon 
                          type="phone" 
                          style={{fontSize: 21, marginRight: 7}} 
                        />
                        <p>380942378556</p>
                      </div>
                      <div className={styles["e-mail"]}>
                        <Icon 
                          type="mail"
                          style={{fontSize: 19, marginRight: 9}}
                        />
                        <p>jackleo@mail.com</p>
                      </div>
                    </div>
                  </Col>
                  <Col
                    xs={{ span: 6, offset: 0 }}
                    sm={{ span: 6, offset: 0 }}
                    md={{ span: 2, offset: 1 }}
                    lg={{ span: 2, offset: 1 }}
                    xl={{ span: 2, offset: 1 }}
                    className={styles["user-nums"]}
                  >
                    <span>0</span>
                    <p>Reviews</p>
                  </Col>
                  <Col
                    xs={{ span: 6, offset: 1 }}
                    sm={{ span: 6, offset: 1 }}
                    md={{ span: 2, offset: 1 }}
                    lg={{ span: 2, offset: 1 }}
                    xl={{ span: 2, offset: 1 }}
                    className={styles["user-nums"]}
                  >
                    <span>1</span>
                    <p>Trips</p>
                  </Col>
                  <Col
                    xs={{ span: 6, offset: 1 }}
                    sm={{ span: 6, offset: 1 }}
                    md={{ span: 3, offset: 1 }}
                    lg={{ span: 3, offset: 1 }}
                    xl={{ span: 3, offset: 1 }}
                    className={styles["user-nums"]}
                  >
                    <span>4</span>
                    <p>Places visited</p>
                  </Col>
                </Row>
              </div>

              <div style={{marginTop: 60}}>
                <Button className={styles["button-review"]}>Write a review</Button>
                <div className={styles["review-block"]}>
                  <h2>Write your first review!</h2>
                  <p>
                     Your opinion is of great importance! Start writing reviews about hotels, entertainment, and more on 
                    <span className={styles["review-block-span"]}> Go&amp;See</span>
                    .
                  </p>    
                </div>
              </div>
            </div>
          </Content>
        </Layout>
      </Layout>
);
};

export default UserPage;