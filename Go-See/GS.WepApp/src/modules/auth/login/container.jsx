import React from "react";
import { connect } from "react-redux";
import { submit } from "redux-form";
import { logIn } from "../redux/actions";

import UI from "./ui";

const FORM_NAME = "log-in-form";

const Container = props => <UI {...props} />;

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch => ({
  onSubmit: () => dispatch(logIn()),
  submit: () => dispatch(submit(FORM_NAME))
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Container);
