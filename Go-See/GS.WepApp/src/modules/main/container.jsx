import React from "react";
import { connect } from "react-redux";
import { City } from "#redux";
import UI from "./ui";

const Container = props => <UI {...props} />;

const mapStateToProps = (state, ownProps) => ({
  city: City.Selectors.getCity(ownProps.cityId)(state)
});

export default connect(
  mapStateToProps,
  null
)(Container);
