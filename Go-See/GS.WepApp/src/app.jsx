import React from "react";
import * as style from "./index.scss";
import { useTranslation } from "react-i18next";

const App = () => {
  const { t } = useTranslation();
  return <div className={style.app}>{t("helloWorld")}</div>;
};

export default App;
