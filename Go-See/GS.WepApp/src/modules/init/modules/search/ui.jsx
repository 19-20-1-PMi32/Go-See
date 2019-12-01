import React, { useState } from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";

import { Input } from "antd";

import styles from "./index.scss";

const UI = ({ search }) => {
  const [loading, changeLoading] = useState(false);
  const { t } = useTranslation();

  const searchHandle = value => {
    changeLoading(!loading);
    search(value);
  };

  return (
    <div className={styles["search-button"]}>
      <Input.Search
        placeholder={t("search.placeholder")}
        enterButton={t("search.button")}
        size="large"
        onSearch={value => searchHandle(value)}
        loading={loading}
      />
    </div>
  );
};

UI.propTypes = {
  search: PropTypes.func.isRequired
};

export default UI;
