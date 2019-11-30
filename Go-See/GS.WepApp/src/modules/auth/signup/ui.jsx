import React, { useState } from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";
import { Form, Icon, Input, Button, Drawer, Tooltip } from "antd";

import styles from "./index.scss";

const RegistrationForm = ({ form, onSubmit, onClose }) => {
  const { t } = useTranslation();
  const [confirmDirty, setConfirmDirty] = useState(false);

  const handleSubmit = e => {
    e.preventDefault();

    form.validateFieldsAndScroll((err, values) => {
      if (!err) {
        onSubmit(values);
      }
    });
  };

  const handleConfirmBlur = e => {
    const { value } = e.target;

    setConfirmDirty(confirmDirty || !!value);
  };

  const compareToFirstPassword = (rule, value, callback) => {
    const warningMessage = t("warnings.auth.inconsistentPassword");
    if (value && value !== form.getFieldValue("password")) {
      callback(warningMessage);
    } else {
      callback();
    }
  };

  const validateToNextPassword = (rule, value, callback) => {
    if (value && confirmDirty) {
      form.validateFields(["confirm"], { force: true });
    }

    callback();
  };

  const TitleWithTooltip = (
    <span>
      {`${t("auth.username")} `}
      <Tooltip title={t("message.username")}>
        <Icon type="question-circle" />
      </Tooltip>
    </span>
  );

  return (
    <Drawer
      title={t("auth.buttons.register")}
      placement="right"
      maskClosable
      onClose={onClose}
      visible
      width={512}
    >
      <div>
        <Form onSubmit={handleSubmit}>
          <Form.Item
            label={t("user.firstName")}
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("firstName", {
              rules: [
                {
                  required: true,
                  message: t("warnings.auth.requiredFirstName"),
                  whitespace: true
                }
              ]
            })(<Input />)}
          </Form.Item>
          <Form.Item
            label={t("user.lastName")}
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("lastName", {
              rules: [
                {
                  required: true,
                  message: t("warnings.auth.requiredLastName"),
                  whitespace: true
                }
              ]
            })(<Input />)}
          </Form.Item>

          <Form.Item
            label={t("user.email")}
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("email", {
              rules: [
                {
                  type: "email",
                  message: t("warnings.auth.validEmail")
                }
              ]
            })(<Input />)}
          </Form.Item>
          <Form.Item
            label={t("user.phone")}
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("phone", { rules: [] })(<Input />)}
          </Form.Item>
          <Form.Item
            label={TitleWithTooltip}
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("username", {
              rules: [
                {
                  required: true,
                  message: t("warnings.auth.requiredUsername")
                }
              ]
            })(<Input />)}
          </Form.Item>
          <Form.Item
            label={t("auth.password")}
            hasFeedback
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("password", {
              rules: [
                {
                  required: true,
                  message: t("warnings.auth.requiredPassword")
                },
                {
                  validator: validateToNextPassword
                }
              ]
            })(<Input.Password />)}
          </Form.Item>
          <Form.Item
            label={t("auth.confirmPassword")}
            hasFeedback
            className={styles["container-margin"]}
          >
            {form.getFieldDecorator("confirm", {
              rules: [
                {
                  required: true,
                  message: t("warnings.auth.confirmPassword")
                },
                {
                  validator: compareToFirstPassword
                }
              ]
            })(<Input.Password onBlur={handleConfirmBlur} />)}
          </Form.Item>
          <Form.Item className={styles["container-margin"]}>
            <Button type="primary" htmlType="submit">
              {t("auth.buttons.register")}
            </Button>
          </Form.Item>
        </Form>
      </div>
    </Drawer>
  );
};

RegistrationForm.propTypes = {
  form: PropTypes.shape({
    validateFields: PropTypes.func.isRequired,
    getFieldDecorator: PropTypes.func.isRequired,
    getFieldValue: PropTypes.func.isRequired,
    validateFieldsAndScroll: PropTypes.func.isRequired
  }).isRequired,
  onSubmit: PropTypes.func.isRequired,
  onClose: PropTypes.func.isRequired
};

export default Form.create({ name: "register" })(RegistrationForm);
