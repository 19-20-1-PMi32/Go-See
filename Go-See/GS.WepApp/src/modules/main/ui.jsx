import React from "react";
import { Layout, Menu, Row, Col, Icon, Input, Dropdown, Avatar, Form, Rate} from "antd";
import { Link } from "react-router-dom";
import classNames from "classnames";
import styles from "./index.scss";

const { Header, Content, Sider } = Layout;
const menu = (
  <Menu className={styles["dropdown-menu-items"]}>
    <Menu.Item key="1">
      Your Profile
    </Menu.Item>
    <Menu.Item key="2">
      Your Trips
    </Menu.Item>
    <Menu.Item key="3">
      Log out
    </Menu.Item>
  </Menu>
);

const Init = () => (
  <Layout>
    <Header className={styles["header-container"]}>
      <Row
        type="flex"
        justify="start"
        align="middle"
      >
        <Col  
          xs={4} 
          sm={4} 
          md={3} 
          lg={2} 
          xl={2}
        >
          <Link to="/">
            <img
              className={styles["logo-img"]}
              src="/src/assets/logo.png"
              alt="Logo"
            />
          </Link>
        </Col>
        <Col 
          xs={{span: 14, offset: 6}}
          sm={{span: 14, offset: 4}}
          md={{span: 9, offset: 4}}
          lg={{span: 8, offset: 5}}
          xl={{span: 6, offset: 6}}
        >
          <Input.Search
            placeholder="Search for attractions"
            onSearch={value => console.log(value)}
            className={styles["search-input"]} 
          />
        </Col>
        <Col
          xs={{span: 3, offset: 13}}
          sm={{span: 3, offset: 12}}
          md={{span: 2, offset: 4}}
          lg={{span: 2, offset: 4}}
          xl={{span: 2, offset: 5}}
        >
          <Dropdown
            overlay={menu} 
            placement="bottomCenter"
            trigger={['click']}
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
          xs={{span: 4, offset: 2}}
          sm={{span: 3, offset: 0}}
          md={{span: 2, offset: 0}}
          lg={{span: 2, offset: 0}}
          xl={{span: 2, offset: 0}}
        >
          <div className={styles["lang-curr"]}>
            <span>EN</span> 
            <span>UAH</span>
          </div>
        </Col>
      </Row>
    </Header>
    <Layout>
      <Sider
        breakpoint="lg"
        collapsedWidth="0"
        style={{backgroundColor: "#fff"}}
      >
        <div className={styles["navbar-header"]}>
          <img
            src="/src/assets/flags/USA.png"
            alt="USA flag"
          />
          <p>New York</p>
        </div>
        <Menu 
          mode="inline" 
          defaultSelectedKeys={['1']}
        >
          <Menu.Item className={styles["menu-item"]} key="1">
            <img
              className={styles["navbar-icon"]}
              src="/src/assets/navbar_icons/top_attractions.png"
              alt="Top Attractions"
            />
            <span className={styles["navbar-text"]}>Top Attractions</span>
          </Menu.Item>
          <Menu.Item className={styles["menu-item"]} key="2">
            <img
              className={styles["navbar-icon"]}
              src="/src/assets/navbar_icons/what_to_eat.png"
              alt="What to eat"
            />
            <span className={styles["navbar-text"]}>What to eat</span>
          </Menu.Item>
          <Menu.Item className={styles["menu-item"]} key="3">
            <img
              className={styles["navbar-icon"]}
              src="/src/assets/navbar_icons/best_things_to_see.png"
              alt="Best things to see"
            />
            <span className={styles["navbar-text"]}>Best things to see</span>
          </Menu.Item>
          <Menu.Item className={styles["menu-item"]} key="4">
            <img
              className={styles["navbar-icon"]}
              src="/src/assets/navbar_icons/best_things_to_do.png"
              alt="Best things to do"
            />
            <span className={styles["navbar-text"]}>Best things to do</span>
          </Menu.Item>
          <Menu.Item key="5">
            <img
              className={styles["navbar-icon"]}
              src="/src/assets/navbar_icons/best_hotels_to_live.png"
              alt="Best hotels to live"
            />
            <span className={styles["navbar-text"]}>Best hotels to live</span>
          </Menu.Item>
        </Menu>
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
        <h2>Top Attractions</h2>
        <div className={styles["main-text"]}>
          <p>New York is really hard to beat when it comes to attractions, it has an incredible range of options to check out and explore. In the Big Apple you can find the most incredible work of engineering and architecture, the museums are filled with art collections of enormous value, not to mention the nearly infinite selection of shops to buy everything you can think of.</p>
        </div>

        <div style={{marginTop: 50}}>
          <Row
            type="flex" 
            justify="center"
            gutter={[{ xs: 8, sm: 16, md: 24, lg: 32 }, 35]} 
            style={{maxWidth: 1320}}
          >
            <Col 
              xs={24} 
              sm={20} 
              md={14} 
              lg={10} 
              xl={8}
            >
              <div className={classNames(styles["attract-component"], styles["first-img"])}>
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
              lg={{ span: 10, offset: 1}} 
              xl={{ span: 8, offset: 1}}
            >
              <div className={classNames(styles["attract-component"], styles["second-img"])}>
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
              <p className={styles["attract-text"]}>St Patrick&#39;s Cathedral</p>
            </Col>
            <Col 
              xs={24} 
              sm={20} 
              md={14} 
              lg={10} 
              xl={8}
            >
              <div className={classNames(styles["attract-component"], styles["third-img"])}>
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
              lg={{ span: 10, offset: 1}} 
              xl={{ span: 8, offset: 1}}
            >
              <div className={classNames(styles["attract-component"], styles["forth-img"])}>
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

export default Init;