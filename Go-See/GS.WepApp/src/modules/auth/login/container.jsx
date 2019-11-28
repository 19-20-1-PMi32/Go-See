import React from "react";
import { connect } from "react-redux";
import { logIn, cancel } from "../redux/actions";

import UI from "./ui";

const Container = props => <UI {...props} />;

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch => ({
  onSubmit: props => dispatch(logIn(props)),
  onClose: () => dispatch(cancel())
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Container);
