import React from "react";
import { Switch, Route } from "react-router";

import Init from "./modules/init";
import Main from "./modules/main";

const App = () => (
  <Switch>
    <Route exect path="/city" component={Main} />
    <Route path="/" component={<Init />} />
  </Switch>
);

export default App;
