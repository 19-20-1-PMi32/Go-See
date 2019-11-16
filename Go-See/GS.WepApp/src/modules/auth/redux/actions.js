import ActionTypes from "./types";

const createAccount = payload => ({
  type: ActionTypes.CREATE_ACCOUNT,
  payload
});

const restorePassword = payload => ({
  type: ActionTypes.RESTORE_PASSWORD,
  payload
});

const logIn = payload => ({
  type: ActionTypes.LOG_IN,
  payload
});

const fail = () => ({
  type: ActionTypes.FAIL
});

const cancel = () => ({
  type: ActionTypes.CANCEL
});

export default {
  createAccount,
  restorePassword,
  logIn,
  cancel,
  fail
};

export { createAccount, restorePassword, logIn, cancel, fail };
