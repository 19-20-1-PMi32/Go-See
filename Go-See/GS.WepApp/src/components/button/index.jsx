import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";

import * as styles from "./index.scss";

const Button = ({
  type,
  color,
  size,
  round,
  status,
  withIcon,
  className,
  children,
  forwardedRef,
  ...other
}) => (
  /* eslint-disable react/button-has-type */
  <button
    type={type}
    className={classNames(
      styles.button,
      styles[color],
      styles[size],
      styles[status],
      {
        [styles["with-icon"]]: withIcon,
        [styles.round]: round
      },
      className
    )}
    ref={forwardedRef}
    {...other}
  >
    {children}
  </button>
);

Button.propTypes = {
  /** Button type. */
  type: PropTypes.oneOf(["button", "submit", "reset"]),
  /** Button content. */
  children: PropTypes.node.isRequired,
  /** Color class. */
  color: PropTypes.oneOf(["red", "green", "blue", "none"]),
  /** Button size */
  size: PropTypes.oneOf(["small", "medium", "large", "default"]),
  /** Makes button round. */
  round: PropTypes.bool,
  /** Button status. */
  status: PropTypes.oneOf(["normal", "disabled", "loading"]),
  /** Button with text and icon */
  withIcon: PropTypes.bool,
  /** Custom class name */
  className: PropTypes.string,
  // eslint-disable-next-line react/forbid-prop-types
  forwardedRef: PropTypes.object
};

Button.defaultProps = {
  type: "button",
  color: "color1",
  size: "default",
  round: false,
  status: "normal",
  withIcon: false,
  className: "",
  forwardedRef: {}
};

export default Button;
