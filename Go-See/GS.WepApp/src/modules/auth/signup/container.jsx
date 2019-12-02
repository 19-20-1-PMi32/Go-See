import React from "react";
import { connect } from "react-redux";
import { createAccount, cancel } from "../redux/actions";

import UI from "./ui";

const Container = props => <UI {...props} />;

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch => ({
  onSubmit: (props) => dispatch(createAccount(props)),
  onClose: () => dispatch(cancel())
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Container);
