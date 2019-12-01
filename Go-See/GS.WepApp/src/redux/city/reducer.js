import ActionTypes from "./types";

const initialState = {};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case ActionTypes.SET:
      return {
        ...state,
        [action.payload.id]: {
          ...action.payload
        }
      };
    default:
      return state;
  }
};

export default reducer;
