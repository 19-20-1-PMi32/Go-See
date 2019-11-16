import React from "react";
import { connect } from "react-redux";
import { logIn } from "../redux/actions";

import UI from "./ui";

const Container = props => <UI {...props} />;

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch => ({
  onSubmit: props => dispatch(logIn(props))
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Container);
