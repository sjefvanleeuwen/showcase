const { merge } = require('webpack-merge');
const common = require('./webpack.common.js');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');

module.exports = merge(common, {
  mode: 'production',
  devtool: 'source-map',
  devServer: {
    port: 3001,
    contentBase: './dist',
  },
  plugins: [
    new ModuleFederationPlugin({
        name: 'container',
        remotes: {
            product_card:
                'product_card@http://localhost:3003/remoteEntry.js',
        },
        shared: ['react', 'react-dom'],
    }),
  ],
});