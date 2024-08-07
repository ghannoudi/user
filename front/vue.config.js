const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true
})
// vue.config.js
module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:7216',
        secure: false, // Use only for local development with self-signed certificates
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    },
  },
};

