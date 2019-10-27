import ActionTypes from "./types";

const getUserInfo = userId => ({
  type: ActionTypes.GET,
  payload: {
    userId
  }
});

const setUserInfo = payload => ({
  type: ActionTypes.SET,
  payload
});

const setUID = userId => ({
  type: ActionTypes.SET_UID,
  payload: {
    userId
  }
});

export default {
  getUserInfo,
  setUserInfo,
  setUID
};

export { getUserInfo, setUserInfo, setUID };
