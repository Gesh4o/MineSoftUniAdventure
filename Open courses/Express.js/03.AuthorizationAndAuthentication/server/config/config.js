const path = require('path')

const rootPath = path.normalize(path.join(__dirname, '/../../'))
const port = process.env.port || 1234

module.exports = {
  development: {
    rootPath: rootPath,
    port: port,
    db: 'mongodb://localhost:27017/articles-and-posts'
  },
  production: {}
}
