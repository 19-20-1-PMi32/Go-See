import React from "react";
import PropTypes from "prop-types";

import Label from "../../label";
import Input from "../../input";

const InputForm = ({
  id,
  label,
  isRequired,
  meta: { touched, error },
  input: { name, value, onChange, onFocus }
}) => (
  <>
    <Label forElem={id} isRequired={isRequired}>
      {label}
    </Label>
    <div>
      <Input
        id={id}
        name={name}
        value={value}
        type="text"
        hasError={!!error && touched}
        aria-describedby={`${id}-error`}
        onChange={onChange}
        onFocus={onFocus}
      />
    </div>
    {touched && error && <p>{error}</p>}
  </>
);

InputForm.propTypes = {
  id: PropTypes.string.isRequired,
  label: PropTypes.string,
  isRequired: PropTypes.bool,
  meta: PropTypes.shape({
    touched: PropTypes.bool,
    error: PropTypes.string
  }),
  input: PropTypes.shape({
    name: PropTypes.string,
    value: PropTypes.string,
    onChange: PropTypes.func,
    onFocus: PropTypes.func
  }).isRequired
};

InputForm.defaultProps = {
  label: "",
  isRequired: false,
  meta: { error: undefined, touched: false }
};

export default InputForm;
