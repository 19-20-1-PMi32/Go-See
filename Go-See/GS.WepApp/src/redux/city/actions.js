import ActionTypes from "./types";

const setCity = payload => ({
  type: ActionTypes.SET,
  payload
});

export default { setCity };

export { setCity };
