import i18n from "i18next";
import { initReactI18next } from "react-i18next";

import en from "#locales/en/translation.json";
import ua from "#locales/ua/translation.json";

const options = lang => ({
  fallbackLng: lang,
  lng: lang,
  defaultNS: "translation",
  languages: ["en", "ua"],
  resources: {
    en: {
      translation: en
    },
    ua: {
      translation: ua
    }
  }
});

i18n.use(initReactI18next).init(options("en"));

export default i18n;