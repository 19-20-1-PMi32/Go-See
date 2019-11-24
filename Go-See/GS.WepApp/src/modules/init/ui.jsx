import React from "react";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { Route } from "react-router";
import Auth from "../auth";
import Search from "./modules/search";
import styles from "./index.scss";

const Init = () => {
  const { t } = useTranslation();

  return (
    <div className={styles["main-page-container"]}>
      <div>
        <Link to="/">
          <img className={styles["logo-img"]} src="/src/assets/logo.png" alt="Logo" />
        </Link>
      </div>
      <div>
        <Auth />
      </div>
      <div className={styles["search-field"]}>
        <Route path="/search">
          <Search />
        </Route>
      </div>
      <div className={styles["main-page-buttons"]}>
        <Link className={styles["search-button"]} to="/search">{`${t("search.title")} ?`}</Link>
        <Link className={styles["login-button"]} to="/login">{t("auth.buttons.login")}</Link>
        <Link className={styles["signup-button"]} to="/signup">{t("auth.buttons.createAccount")}</Link>
      </div>
    </div>
  );
};

export default Init;
