import instance from "#utils/instanceAPI";

const getUserInfo = async userId => {
  const response = await instance.get(`/user/${userId}`);

  return response.data;
};

export { getUserInfo };

export default { getUserInfo };
