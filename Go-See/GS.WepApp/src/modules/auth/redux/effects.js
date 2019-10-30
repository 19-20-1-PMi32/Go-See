import { put, takeEvery, select } from "redux-saga/effects";
import { push } from "connected-react-router";
import { getFormValues } from "redux-form";
import hash from "object-hash";

import ActionTypes from "./types";
import AuthAPI from "./api";
import { User } from "#redux";

export function* cancel() {
  yield put(push("../"));
}

export function* createAccount() {
  const form = "create-account-form";
  const values = yield select(getFormValues(form));
  try {
    if (values.password === values.confirmPassword) {
      const passwordHash = hash({
        login: values.login,
        passsword: values.password
      });

      const sendedValue = {
        firstName: values.firstName,
        lastName: values.lastName,
        email: values.email,
        phone: values.phone,
        login: values.login,
        passwordHash
      };

      const api = AuthAPI.createAccount(sendedValue);
      const userId = yield api;

      yield put(User.Actions.setUID(userId));
      yield put(push("/search"));
    }
  } catch (error) {
    console.error(error);
  }
}

export function* logIn() {
  const form = "log-in-form";
  const values = yield select(getFormValues(form));

  const passwordHash = hash({
    login: values.login,
    passsword: values.password
  });

  try {
    const api = AuthAPI.logIn(values.login, passwordHash);
    const userId = yield api;

    yield put(User.Actions.setUID(userId));
    yield put(push("/search"));
  } catch (error) {
    console.error(error);
  }
}

// export function* restorePassword(action) {}

export default function* root() {
  yield takeEvery(ActionTypes.CREATE_ACCOUNT, createAccount);
  // yield takeEvery(ActionTypes.RESTORE_PASSWORD, restorePassword);
  yield takeEvery(ActionTypes.LOG_IN, logIn);
  yield takeEvery(ActionTypes.CANCEL, cancel);
}
