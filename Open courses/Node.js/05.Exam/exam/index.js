const http = require('http')
const port = 1234

const handlers = (require('./scripts/handlers/index'))

http.createServer((req, res) => {
  for (let handler of handlers) {
    if (!handler(req, res)) {
      break
    }
  }
}).listen(port)
