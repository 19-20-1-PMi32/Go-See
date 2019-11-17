const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const webpack = require("webpack");

module.exports = {
  target: "web",
  entry: {
    main: path.resolve(__dirname, "./src/root.jsx")
  },
  devtool: "inline-source-map",
  devServer: {
    historyApiFallback: true
  },
  output: {
    publicPath: "/"
  },
  output: {
    path: path.resolve(__dirname, "./build"),
    filename: "[name].js",
    library: "name-app",
    libraryTarget: "umd",
    publicPath: process.env.PUBLIC_URL,
    chunkFilename: "[name].bundle.js"
  },
  resolve: {
    extensions: [".js", ".jsx"],
    alias: {
      "#components": path.resolve("./src/components"),
      "#locales": path.resolve("./src/assets/locales"),
      "#utils": path.resolve("./src/utils"),
      "#mocks": path.resolve("./__mocks__"),
      "#redux": path.resolve("./src/redux")
    }
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        include: [/src/],
        use: [
          {
            loader: "babel-loader",
            options: {
              presets: [
                [
                  "@babel/preset-env",
                  {
                    useBuiltIns: "entry",
                    corejs: "3"
                  }
                ],
                "@babel/preset-react"
              ],
              plugins: [
                "@babel/plugin-transform-runtime",
                "@babel/plugin-proposal-class-properties",
                [
                  "import",
                  {
                    libraryName: "antd",
                    libraryDirectory: "es",
                    style: "css"
                  }
                ]
              ]
            }
          }
        ]
      },
      {
        test: /\.scss$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader",
            options: {
              import: true,
              modules: {
                localIdentName: "[local]_[hash:base64:4]"
              }
            }
          },
          {
            loader: "postcss-loader",
            options: {
              plugins: () => [require("autoprefixer"), require("css-mqpacker")]
            }
          },
          "sass-loader"
        ]
      },
      {
        test: /\.css$/,
        use: [{ loader: "style-loader" }, { loader: "css-loader" }]
      },
      //list of additional loaders
      {
        test: /\.(svg|png|eot|ttf|woff|woff2|bmp|wav|gif|jpe?g)(\?v=[a-z0-9]\.[a-z0-9]\.[a-z0-9])?$/,
        use: "url-loader?limit=10000&name=fonts/[hash].[ext]"
      }
    ]
  },
  externals: {
    //Modules requested at runtime from the environment
    react: {
      root: "React",
      commonjs2: "react",
      commonjs: "react",
      amd: "react",
      umd: "react"
    },
    "react-dom": {
      root: "ReactDOM",
      commonjs2: "react-dom",
      commonjs: "react-dom",
      amd: "react-dom",
      umd: "react-dom"
    }
  },

  plugins: [
    new HtmlWebpackPlugin({
      template: "./public/index.html"
    }),
    new MiniCssExtractPlugin({
      filename: "[name].css"
    }),
    new webpack.DefinePlugin({
      "global.GENTLY": false,
      GATEWAY_URL:
        process.env.GATEWAY_URL instanceof String
          ? process.env.GATEWAY_URL
          : JSON.stringify(process.env.GATEWAY_URL),
      MOCK_API:
        process.env.MOCK_API instanceof String
          ? process.env.MOCK_API
          : JSON.stringify(process.env.MOCK_API)
    })
  ]
};
