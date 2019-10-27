import React from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";
import { Field, reduxForm } from "redux-form";

import { FormField } from "#components";

const UI = reduxForm({
  form: "create-account-form"
})(({ onSubmit, submit }) => {
  const { t } = useTranslation();

  const handleSubmit = () => {
    return new Promise(() => onSubmit()).then();
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <Field
          id="firstName"
          name="firstName"
          label={t("user.firstName")}
          isRequired
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="lastName"
          name="lastName"
          label={t("user.lastName")}
          isRequired
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="login"
          name="login"
          label={t("auth.login")}
          isRequired
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="email"
          name="email"
          label={t("user.email")}
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="phone"
          name="phone"
          label={t("user.phone")}
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="password"
          name="password"
          label={t("auth.password")}
          isRequired
          component={FormField.Input}
        />
      </div>
      <div>
        <Field
          id="confirmPassword"
          name="confirmPassword"
          label={t("auth.confirmPassword")}
          isRequired
          component={FormField.Input}
        />
      </div>
      <button type="button" onClick={submit}>
        {t("auth.buttons.signup")}
      </button>
    </form>
  );
});

UI.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  submit: PropTypes.func.isRequired
};

export default UI;
