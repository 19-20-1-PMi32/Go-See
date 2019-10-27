import axios from "axios";
// import MockAdapter from "axios-mock-adapter";

const instance = axios.create({
  baseURL: GATEWAY_URL
});

instance.interceptors.request.use(config => {
  const newConfig = config;
  newConfig.headers = {
    "Content-Type": "application/json"
  };
  return newConfig;
});
// if (MOCK_API === "true") {
//   // eslint-disable-next-line no-console
//   console.log("Mock API is enabled");

//   const mock = new MockAdapter(instance, { delayResponse: 2 * 1000 });

//   // mock.onGet("/metadata/").reply(200, MetadataMock.default);
//   mock.onPost(/.*/).reply(200);
//   mock.onPatch(/.*/).reply(200);
//   mock.onPut(/.*/).reply(200);
//   mock.onDelete(/.*/).reply(200);
// }

export default instance;
