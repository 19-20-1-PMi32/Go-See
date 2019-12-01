import React from "react";
import { connect } from "react-redux";
import {searchByName} from "../redux/actions";

import UI from "./ui";

const Container = props => <UI {...props} />;

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch => ({
  search: name => dispatch(searchByName(name)),
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Container);
