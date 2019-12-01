import { put, takeEvery } from "redux-saga/effects";
import { push } from "connected-react-router";

import ActionTypes from "./types";
import SearchAPI from "./api";
import { City } from "#redux";

export function* searchByName(action) {
  const name = action.payload;

  try {
    const api = SearchAPI.searchByName(name);
    const cityData = yield api;

    yield put(City.Actions.setCity(cityData));
    yield put(push(`/city/${cityData.id}`));
  } catch (error) {
    console.error(error);
  }
}

export default function* root() {
  yield takeEvery(ActionTypes.SEARCH_BY_NAME, searchByName);
}
