import { createStore } from "redux-dynamic-modules";
import { getSagaExtension } from "redux-dynamic-modules-saga";
import { applyMiddleware } from "redux";
import { connectRouter, routerMiddleware } from "connected-react-router";
import User from "./user";
import City from "./city";

const rootModule = history => ({
  id: "root",
  /* reducer */
  reducerMap: {
    router: connectRouter(history),
    user: User.reducer,
    cities: City.reducer
  },
  /* middlewares */
  middlewares: [routerMiddleware(history)],
  /* sagas */
  sagas: [User.Effects]
});

const configureStore = (initalStore, history) => {
  const store = createStore(
    initalStore,
    [applyMiddleware()],
    [getSagaExtension()],
    rootModule(history)
  );

  return store;
};

export { User, City, configureStore };
