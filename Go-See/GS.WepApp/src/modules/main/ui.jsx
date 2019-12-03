import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";
import { useTranslation } from "react-i18next";

import {
  Layout,
  Menu,
  Row,
  Col,
  Icon,
  Input,
  Dropdown,
  Avatar,
  Select
} from "antd";

import { Link } from "react-router-dom";

import i18n from "#utils/i18n";

import styles from "./index.scss";

const { Header, Content, Sider } = Layout;

const City = ({ city }) => {
  const { t } = useTranslation();

  const NavBar = (
    <Menu className={styles["dropdown-menu-items"]}>
      <Menu.Item key="1">
        <Link to="/account">{t("navigation.profile")}</Link>
      </Menu.Item>
      <Menu.Item key="2">{t("navigation.trips")}</Menu.Item>
      <Menu.Item key="3">{t("navigation.logout")}</Menu.Item>
    </Menu>
  );

  const changeLanguage = lng => {
    i18n.changeLanguage(lng.key);
  };

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
            md={{ span: 8, offset: 3 }}
            lg={{ span: 8, offset: 5 }}
            xl={{ span: 6, offset: 6 }}
          >
            <Input.Search
              placeholder={t("city.search.placeholder")}
              onSearch={value => console.log(value)}
              className={styles["search-input"]}
            />
          </Col>
          <Col
            xs={{ span: 3, offset: 10 }}
            sm={{ span: 3, offset: 10 }}
            md={{ span: 1, offset: 2 }}
            lg={{ span: 1, offset: 3 }}
            xl={{ span: 1, offset: 5 }}
          >
            <Dropdown
              overlay={NavBar}
              placement="bottomCenter"
              trigger={["click"]}
            >
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
            xs={{ span: 10, offset: 1 }}
            sm={{ span: 7, offset: 2 }}
            md={{ span: 5, offset: 1 }}
            lg={{ span: 4, offset: 1 }}
            xl={{ span: 4, offset: 0 }}
          >
            <div className={styles["lang-curr"]}>
              <Select
                labelInValue
                defaultValue={{ key: "en" }}
                style={{ width: 70 }}
                onChange={changeLanguage}
              >
                <Select.Option value="en">ENG</Select.Option>
                <Select.Option value="ua">UKR</Select.Option>
              </Select>
              <Select
                labelInValue
                defaultValue={{ key: "usd" }}
                style={{ width: 70 }}
                onChange={() => {}}
              >
                <Select.Option value="usd">USD</Select.Option>
                <Select.Option value="uah">UAH</Select.Option>
              </Select>
            </div>
          </Col>
        </Row>
      </Header>
      <Layout>
        <Sider
          breakpoint="lg"
          collapsedWidth="0"
          style={{ backgroundColor: "#fff" }}
        >
          <div className={styles.sider}>
            <div className={styles["navbar-header"]}>
              <img src="/src/assets/flags/USA.png" alt="USA flag" />
              <p>New York</p>
            </div>
            <Menu
              mode="inline"
              defaultSelectedKeys={["1"]}
              className={styles["sider-menu"]}
            >
              <Menu.Item className={styles["menu-item"]} key="1">
                <img
                  className={styles["navbar-icon"]}
                  src="/src/assets/navbar_icons/top_attractions.png"
                  alt="Top Attractions"
                />
                <span className={styles["navbar-text"]}>
                  {t("city.navigation.top")}
                </span>
              </Menu.Item>
              <Menu.Item className={styles["menu-item"]} key="2">
                <img
                  className={styles["navbar-icon"]}
                  src="/src/assets/navbar_icons/what_to_eat.png"
                  alt="What to eat"
                />
                <span className={styles["navbar-text"]}>
                  {t("city.navigation.whatToEat")}
                </span>
              </Menu.Item>
              <Menu.Item className={styles["menu-item"]} key="3">
                <img
                  className={styles["navbar-icon"]}
                  src="/src/assets/navbar_icons/best_things_to_see.png"
                  alt="Best things to see"
                />
                <span className={styles["navbar-text"]}>
                  {t("city.navigation.bestToSee")}
                </span>
              </Menu.Item>
              <Menu.Item className={styles["menu-item"]} key="4">
                <img
                  className={styles["navbar-icon"]}
                  src="/src/assets/navbar_icons/best_things_to_do.png"
                  alt="Best things to do"
                />
                <span className={styles["navbar-text"]}>
                  {t("city.navigation.bestToDo")}
                </span>
              </Menu.Item>
              <Menu.Item key="5">
                <img
                  className={styles["navbar-icon"]}
                  src="/src/assets/navbar_icons/best_hotels_to_live.png"
                  alt="Best hotels to live"
                />
                <span className={styles["navbar-text"]}>
                  {t("city.navigation.bestToLive")}
                </span>
              </Menu.Item>
            </Menu>
          </div>
        </Sider>
        <Content
          style={{
            background: "#fff",
            paddingTop: 35,
            paddingLeft: 50,
            paddingRight: 50,
            paddingBottom: 35,
            minHeight: 280
          }}
        >
          <h2>{t("city.topAttractions")}</h2>
          <div className={styles["main-text"]}>
            <p>
              New York is really hard to beat when it comes to attractions, it
              has an incredible range of options to check out and explore. In
              the Big Apple you can find the most incredible work of engineering
              and architecture, the museums are filled with art collections of
              enormous value, not to mention the nearly infinite selection of
              shops to buy everything you can think of.
            </p>
          </div>

          <div style={{ marginTop: 50 }}>
            <Row
              type="flex"
              justify="center"
              gutter={[{ xs: 8, sm: 16, md: 24, lg: 32 }, 35]}
              style={{ maxWidth: 1320 }}
            >
              <Col xs={24} sm={20} md={14} lg={10} xl={8}>
                <div
                  className={classNames(
                    styles["attract-component"],
                    styles["first-img"]
                  )}
                >
                  <Icon
                    type="info-circle"
                    theme="twoTone"
                    twoToneColor="#68aae3"
                    className={styles["info-icon"]}
                  />
                  <div className={styles["star-list"]}>
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="twoTone" twoToneColor="#ebb434" />
                  </div>
                </div>
                <p className={styles["attract-text"]}>Guggenheim Museum</p>
              </Col>
              <Col
                xs={24}
                sm={20}
                md={14}
                lg={{ span: 10, offset: 1 }}
                xl={{ span: 8, offset: 1 }}
              >
                <div
                  className={classNames(
                    styles["attract-component"],
                    styles["second-img"]
                  )}
                >
                  <Icon
                    type="info-circle"
                    theme="twoTone"
                    twoToneColor="#68aae3"
                    className={styles["info-icon"]}
                  />
                  <div className={styles["star-list"]}>
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                  </div>
                </div>
                <p className={styles["attract-text"]}>
                  St Patrick&#39;s Cathedral
                </p>
              </Col>
              <Col xs={24} sm={20} md={14} lg={10} xl={8}>
                <div
                  className={classNames(
                    styles["attract-component"],
                    styles["third-img"]
                  )}
                >
                  <Icon
                    type="info-circle"
                    theme="twoTone"
                    twoToneColor="#68aae3"
                    className={styles["info-icon"]}
                  />
                  <div className={styles["star-list"]}>
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                  </div>
                </div>
                <p className={styles["attract-text"]}>Empire State Building</p>
              </Col>
              <Col
                xs={24}
                sm={20}
                md={14}
                lg={{ span: 10, offset: 1 }}
                xl={{ span: 8, offset: 1 }}
              >
                <div
                  className={classNames(
                    styles["attract-component"],
                    styles["forth-img"]
                  )}
                >
                  <Icon
                    type="info-circle"
                    theme="twoTone"
                    twoToneColor="#68aae3"
                    className={styles["info-icon"]}
                  />
                  <div className={styles["star-list"]}>
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                    <Icon type="star" theme="filled" />
                  </div>
                </div>
                <p className={styles["attract-text"]}>Broadway</p>
              </Col>
            </Row>
          </div>
        </Content>
      </Layout>
    </Layout>
  );
};

City.propTypes = {
  city: PropTypes.shape({}).isRequired
};

export default City;
