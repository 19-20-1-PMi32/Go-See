import React from "react";
import { DynamicModuleLoader } from "redux-dynamic-modules";
import { Route } from "react-router-dom";

import { configureStore } from "./redux";
import LogIn from "./login";
import SignUp from "./signup";

const Auth = () => {
  return (
    <DynamicModuleLoader modules={[configureStore()]}>
      <Route exact path="/login" component={LogIn} />
      <Route exact path="/signup" component={SignUp} />
    </DynamicModuleLoader>
  );
};

export default Auth;
