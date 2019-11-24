import React from "react";
import { Input } from "antd";
import styles from "./index.scss";

const UI = () => (
  <div className={styles["search-button"]}>
    <Input.Search
      placeholder="What are you looking for ?"
      enterButton="Search"
      size="large"
      onSearch={value => console.log(value)}
    />
  </div>
);

export default UI;