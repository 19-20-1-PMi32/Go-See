import React from "react";
import { Switch, Route } from "react-router";

import Init from "./modules/init";

const App = () => (
  <Switch>
    <Route path="/">
      <Init />
    </Route>
  </Switch>
);

export default App;
