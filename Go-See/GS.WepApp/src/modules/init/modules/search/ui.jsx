import React from "react";
import PropTypes from "prop-types";

import { Input } from "antd";

import styles from "./index.scss";

const UI = ({ search }) => (
  <div className={styles["search-button"]}>
    <Input.Search
      placeholder="What are you looking for ?"
      enterButton="Search"
      size="large"
      onSearch={value => search(value)}
    />
  </div>
);

UI.propTypes = {
  search: PropTypes.func.isRequired
};

export default UI;
