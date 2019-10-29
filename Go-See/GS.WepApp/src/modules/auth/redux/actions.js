import ActionTypes from "./types";

const createAccount = () => ({
  type: ActionTypes.CREATE_ACCOUNT
});

const restorePassword = payload => ({
  type: ActionTypes.RESTORE_PASSWORD,
  payload
});

const logIn = () => ({
  type: ActionTypes.LOG_IN
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
