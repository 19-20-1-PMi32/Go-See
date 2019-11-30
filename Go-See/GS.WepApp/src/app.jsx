import React from "react";
import { Switch, Route } from "react-router-dom";

import Init from "./modules/init";
import Main from "./modules/main";

const App = () => (
  <Switch>
    <Route path="/" component={Init} />
    <Route
      path="/city/:cityId"
      component={routerProps => (
        <Main cityId={routerProps.match.params.cityId} />
      )}
    />
  </Switch>
);

export default App;
