import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "connected-react-router";
import { I18nextProvider } from "react-i18next";
import { createBrowserHistory } from "history";

import { Switch, Route } from "react-router-dom";
import Init from "./modules/init";
import Main from "./modules/main";

import { configureStore } from "./redux";
import i18n from "#utils/i18n";

import "antd/dist/antd.css";

const history = createBrowserHistory();

const INITIAL_STATE = window.ReduxInitialState || {
  user: {}
};

export const Store = configureStore(INITIAL_STATE, history);

const renderApp = () => {
  const element = document.getElementById("go-see-app");

  ReactDOM.render(
    <Provider store={Store}>
      <ConnectedRouter history={history}>
        <I18nextProvider i18n={i18n}>
          <Switch>
            <Route
              path="/city/:cityId"
              component={routerProps => (
                <Main cityId={routerProps.match.params.cityId} />
              )}
            />
            <Route path="/" component={Init} />
          </Switch>
        </I18nextProvider>
      </ConnectedRouter>
    </Provider>,
    element
  );
};
renderApp();
