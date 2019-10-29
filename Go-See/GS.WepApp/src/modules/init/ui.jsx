import React from "react";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import { Route } from "react-router";
import Auth from "../auth";
import Search from "./modules/search";

const Init = () => {
  const { t } = useTranslation();

  return (
    <>
      <div>
        <Auth />
      </div>
      <div>
        <Route path="/search">
          <Search />
        </Route>
      </div>
      <div>
        <Link to="/search">{`${t("search.title")}?`}</Link>
        <Link to="/login">{t("auth.buttons.login")}</Link>
        <Link to="/signup">{t("auth.buttons.signup")}</Link>
      </div>
    </>
  );
};

export default Init;
