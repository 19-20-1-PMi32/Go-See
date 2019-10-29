import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";

import styles from "./index.scss";

const Input = ({
  id,
  name,
  value,
  hasError,
  disabled,
  className,
  ...other
}) => (
  <input
    type="text"
    id={id}
    name={name}
    value={value}
    disabled={disabled}
    className={classNames(
      styles["text-input"],
      { [styles["has-error"]]: hasError },
      className
    )}
    {...other}
  />
);

Input.propTypes = {
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  /** Makes input disabled. */
  disabled: PropTypes.bool,
  /** Makes input with error. */
  hasError: PropTypes.bool,
  /** Value */
  value: PropTypes.string,
  /** Custom class name */
  className: PropTypes.string
};

Input.defaultProps = {
  className: "",
  disabled: false,
  hasError: false,
  value: ""
};

export default Input;
