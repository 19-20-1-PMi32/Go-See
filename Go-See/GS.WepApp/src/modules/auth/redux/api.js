import instance from "#utils/instanceAPI";

const createAccount = async user => {
  const response = await instance.post(`/user/new`, user);

  return response.data;
};

const restorePassword = async (login, password) => {
  const response = await instance.post(
    `/user/${login}/restore-password`,
    password
  );

  return response.data;
};

const logIn = async (login, password) => {
  const response = await instance.post("user/log-in", {
    login,
    password
  });

  return response.data;
};

export default {
  createAccount,
  restorePassword,
  logIn
};
