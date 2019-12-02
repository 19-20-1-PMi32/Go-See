import instance from "#utils/instanceAPI";

const searchByName = async cityName => {
  const response = await instance.get(`/city/name/${cityName}/places`);

  return response.data;
};

export default {
  searchByName
};
