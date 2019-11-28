import React, { useState } from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";
import { Form, Icon, Input, Button, Drawer } from "antd";

import styles from "./index.scss";

const LoginForm = ({ form, onSubmit, onClose, visible }) => {
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
    <Drawer
      title={t("auth.buttons.login")}
      placement="right"
      closable={true}
      onClose={onClose}
      visible={visible}>
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
    </Drawer>
  );
};

LoginForm.propTypes = {
  form: PropTypes.shape({
    validateFields: PropTypes.func.isRequired,
    getFieldDecorator: PropTypes.func.isRequired
  }).isRequired,
  onSubmit: PropTypes.func.isRequired,
  onClose: PropTypes.func.isRequired,
  visible: PropTypes.bool.isRequired
};

export default Form.create({ name: "login" })(LoginForm);
