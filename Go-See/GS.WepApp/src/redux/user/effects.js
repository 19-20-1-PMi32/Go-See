import { put, takeEvery } from "redux-saga/effects";

import ActionTypes from "./types";
import { setUserInfo } from "./actions";
import * as UserAPI from "./api";

export function* getUserInfo(action) {
  try {
    const { userId } = action.payload;

    const userInfo = UserAPI.getUserInfo(userId);

    yield put(setUserInfo(userInfo));
  } catch (error) {
    console.error(error);
  }
}

export default function* root() {
  yield takeEvery(ActionTypes.GET, getUserInfo);
}
