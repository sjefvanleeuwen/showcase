const { merge } = require('webpack-merge');
const common = require('./webpack.common.js');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');

module.exports = merge(common, {
  mode: 'development',
  devtool: 'inline-source-map',
  devServer: {
    port: 3001,
    contentBase: './dist',
    open: true
  },
  plugins: [
    new ModuleFederationPlugin({
        name: 'container',
        remotes: {
            product_card:
                'product_card@http://localhost:3003/remoteEntry.js',
            form_engine:
                'form_engine@http://localhost:3002/remoteEntry.js',
        },
        shared: ['react', 'react-dom'],
    }),
  ],
});