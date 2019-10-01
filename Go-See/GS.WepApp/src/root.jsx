import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "connected-react-router";
import { I18nextProvider } from "react-i18next";
import { createBrowserHistory } from "history";

import App from "./app";
import { configureStore } from "./redux";

import i18n from "#utils/i18n.js";

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
          <App />
        </I18nextProvider>
      </ConnectedRouter>
    </Provider>,
    element
  );
};
renderApp();
