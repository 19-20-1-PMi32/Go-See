import Actions from "./actions";
import ActionTypes from "./types";
import Effects from "./effects";

const configureStore = () => ({
  id: "search",
  reducerMap: {},
  sagas: [Effects]
});

export { ActionTypes, Actions, Effects, configureStore };

export default { ActionTypes, Actions, Effects, configureStore };
