import ActionTypes from "./types";

const initialState = {
  UID: "00000000-0000-0000-0000-000000000000",
  general: {
    login: "",
    firstName: "",
    lastName: "",
    email: "",
    phone: ""
  },
  trips: [],
  reviews: []
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case ActionTypes.GET:
      return {
        ...state,
        fetching: true
      };
    case ActionTypes.SET:
      return {
        ...state,
        ...action.payload,
        fetching: false
      };
    case ActionTypes.SET_UID:
      return {
        ...state,
        UID: action.payload.userId,
        fetching: false
      };
    default:
      return state;
  }
};

export default reducer;
