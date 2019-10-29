import React from "react";
import { DynamicModuleLoader } from "redux-dynamic-modules";
import { Route } from "react-router";

import { configureStore } from "./redux";
import LogIn from "./login";
import SignUp from "./signup";

const Auth = () => {
  return (
    <DynamicModuleLoader modules={[configureStore()]}>
      <Route path="/login" component={LogIn} />
      <Route path="/signup" component={SignUp} />
    </DynamicModuleLoader>
  );
};

export default Auth;
