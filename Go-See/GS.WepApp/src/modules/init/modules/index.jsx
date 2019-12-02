import React from "react";
import { DynamicModuleLoader } from "redux-dynamic-modules";
import { Route } from "react-router-dom";

import { configureStore } from "./redux";
import SearchUI from "./search";

const Search = () => {
  return (
    <DynamicModuleLoader modules={[configureStore()]}>
      <Route exact path="/search" component={SearchUI} />
    </DynamicModuleLoader>
  );
};

export default Search;
