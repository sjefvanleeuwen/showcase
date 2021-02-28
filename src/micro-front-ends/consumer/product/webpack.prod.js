const { merge } = require('webpack-merge');
const common = require('./webpack.common.js');

module.exports = merge(common, {
  mode: 'production',
  devtool: 'source-map',
  devServer: {
    port: 3001,
    contentBase: './dist',
  },
});