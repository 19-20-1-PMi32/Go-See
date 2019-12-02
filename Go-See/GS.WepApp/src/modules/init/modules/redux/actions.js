import ActionTypes from "./types";

const searchByName = payload => ({
  type: ActionTypes.SEARCH_BY_NAME,
  payload
});

export default { searchByName };

export { searchByName };
