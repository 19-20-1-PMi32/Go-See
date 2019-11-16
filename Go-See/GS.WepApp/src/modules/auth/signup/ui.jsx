import React, { useState } from "react";
import PropTypes from "prop-types";
import { useTranslation } from "react-i18next";
import { Form, Input, Tooltip, Icon, Button } from "antd";
import styles from "./index.scss";

const RegistrationForm = ({ form, onSubmit }) => {
  const [confirmDirty, setConfirmDirty] = useState(false);
  const { t } = useTranslation();

  const formItemLayout = {
    labelCol: {
      xs: { span: 24 },
      sm: { span: 8 }
    },
    wrapperCol: {
      xs: { span: 24 },
      sm: { span: 16 }
    }
  };

  const tailFormItemLayout = {
    wrapperCol: {
      xs: {
        span: 24,
        offset: 0
      },
      sm: {
        span: 16,
        offset: 8
      }
    }
  };

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
    if (value && value !== form.getFieldValue("password")) {
      callback("Two passwords that you enter is inconsistent!");
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
        <Icon type="question-circle-o" />
      </Tooltip>
    </span>
  );

  return (
    <div className={styles["register-form-container"]}>
      <Form {...formItemLayout} onSubmit={handleSubmit}>
        <Form.Item label={t("user.firstName")}>
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
        <Form.Item label={t("user.lastName")}>
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

        <Form.Item label={t("user.email")}>
          {form.getFieldDecorator("email", {
            rules: [
              {
                type: "email",
                message: t("warnings.auth.validEmail")
              }
            ]
          })(<Input />)}
        </Form.Item>
        <Form.Item label={t("user.phone")}>
          {form.getFieldDecorator("phone", { rules: [] })(<Input />)}
        </Form.Item>
        <Form.Item label={TitleWithTooltip}>
          {form.getFieldDecorator("username", {
            rules: [
              {
                required: true,
                message: t("warnings.auth.requiredUsername")
              }
            ]
          })(<Input />)}
        </Form.Item>
        <Form.Item label={t("auth.password")} hasFeedback>
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
        <Form.Item label={t("auth.confirmPassword")} hasFeedback>
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
        <Form.Item {...tailFormItemLayout}>
          <Button type="primary" htmlType="submit">
            {t("auth.buttons.register")}
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};

RegistrationForm.propTypes = {
  form: PropTypes.shape({
    validateFields: PropTypes.func.isRequired,
    getFieldDecorator: PropTypes.func.isRequired,
    getFieldValue: PropTypes.func.isRequired,
    validateFieldsAndScroll: PropTypes.func.isRequired
  }).isRequired,
  onSubmit: PropTypes.func.isRequired
};

export default Form.create({ name: "register" })(RegistrationForm);
