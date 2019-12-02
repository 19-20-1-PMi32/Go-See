import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";

import { Col, Icon } from "antd";

import styles from "./index.scss";

const Place = ({ place }) => {
  const stars = [];

  for (let i = 0; i < 5; i += 1) {
    stars.push(<Icon type="star" theme="filled" />);
  }
  for (let i = 0; i < 5; i += 1) {
    stars.push(<Icon type="star" theme="twoTone" twoToneColor="#ebb434" />);
  }

  return (
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
          {stars}
          <Icon type="star" theme="filled" />
          <Icon type="star" theme="filled" />
          <Icon type="star" theme="filled" />
          <Icon type="star" theme="filled" />
          <Icon type="star" theme="twoTone" twoToneColor="#ebb434" />
        </div>
      </div>
      <p className={styles["attract-text"]}>St Patrick&#39;s Cathedral</p>
    </Col>
  );
};

Place.propTypes = {
  place: PropTypes.shape({}).isRequired
};

export default Place;
