import React from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";
import { Form, Icon, Input, Button } from "antd";

import styles from "./index.scss";



const LoginForm = ({ form, onSubmit }) => {
  const { t } = useTranslation();

  const handleSubmit = e => {
    e.preventDefault();
    form.validateFields((err, values) => {
      if (!err) {
        onSubmit(values);
      }
    });
  };

  
  return (
    <div className={styles["login-form-container"]}>
      <Form onSubmit={handleSubmit}>
        <Form.Item>
          {form.getFieldDecorator("username", {
            rules: [
              { required: true, message: t("warnings.auth.requiredUsername") }
            ]
          })(
            <Input
              prefix={<Icon type="user" />}
              placeholder={t("auth.username")}
            />
          )}
        </Form.Item>

        <Form.Item>
          {form.getFieldDecorator("password", {
            rules: [
              { required: true, message: t("warnings.auth.requiredPassword") }
            ]
          })(
            <Input
              prefix={<Icon type="lock" />}
              type="password"
              placeholder={t("auth.password")}
            />
          )}
        </Form.Item>

        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
          >
            {t("auth.buttons.login")}
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};

LoginForm.propTypes = {
  form: PropTypes.shape({
    validateFields: PropTypes.func.isRequired,
    getFieldDecorator: PropTypes.func.isRequired
  }).isRequired,
  onSubmit: PropTypes.func.isRequired
};

export default Form.create({ name: "login" })(LoginForm);
