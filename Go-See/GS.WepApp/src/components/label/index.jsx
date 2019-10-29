/* eslint-disable jsx-a11y/label-has-for */
import React from "react";
import PropTypes from "prop-types";
import classNames from "classnames";

import styles from "./index.scss";

const Label = ({
  forElem,
  isRequired,
  children,
  className,
  ...other
}) => (
  <label htmlFor={forElem} className={className} {...other}>
    {children}
    {isRequired && (
      <span
        className={classNames(
          styles.asterisk,
          styles[`u-colorRed`],
          styles[`u-fontBold`]
        )}
      >
        *
      </span>
    )}
  </label>
);

Label.propTypes = {
  /** Label attribute `for` */
  forElem: PropTypes.string,
  /** Custom class name */
  className: PropTypes.string,
  /** If `true` then mark as required */
  isRequired: PropTypes.bool,
  /** Children node */
  children: PropTypes.node
};

Label.defaultProps = {
  className: "",
  isRequired: false,
  forElem: "",
  children: ""
};

export default Label;
