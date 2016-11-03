const path = require('path')

module.exports = {
  development: {
    port: 2000,
    rootFolder: path.normalize(path.join(__dirname, '/../')),
    connectionString: 'mongodb://localhost:27017/forum'
  },
  production: {
  }
}
