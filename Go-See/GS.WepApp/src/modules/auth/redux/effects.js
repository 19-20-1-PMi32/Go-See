import { put, takeEvery } from "redux-saga/effects";
import { push } from "connected-react-router";
import hash from "object-hash";

import ActionTypes from "./types";
import AuthAPI from "./api";
import { User } from "#redux";

export function* cancel() {
  yield put(push("../"));
}

export function* createAccount(action) {
  const values = action.payload;

  try {
    if (values.password === values.confirm) {
      const passwordHash = hash({
        login: values.username,
        passsword: values.password
      });

      const sendedValue = {
        firstName: values.firstName,
        lastName: values.lastName,
        email: values.email,
        phone: values.phone,
        login: values.username,
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

export function* logIn(action) {
  const values = action.payload;

  const passwordHash = hash({
    login: values.username,
    passsword: values.password
  });

  try {
    const api = AuthAPI.logIn(values.username, passwordHash);
    const userId = yield api;

    yield put(User.Actions.setUID(userId));
    yield put(push("/search"));
  } catch (error) {
    console.error(error);
  }
}

export default function* root() {
  yield takeEvery(ActionTypes.CREATE_ACCOUNT, createAccount);
  yield takeEvery(ActionTypes.LOG_IN, logIn);
  yield takeEvery(ActionTypes.CANCEL, cancel);
}
