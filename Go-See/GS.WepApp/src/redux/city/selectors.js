const getCity = cityId => state => {
    return state.cities[cityId];
};

export default {
  getCity
};

export { getCity };
