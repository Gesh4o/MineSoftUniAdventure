const port = 1234

const homeHandler = require('./handlers/home-handler')
const downloadHandler = require('./handlers/upload-file-handler')
const displayAllHandler = require('./handlers/display-all-files')
const detailsFileHander = require('./handlers/file-details')
const handlers = [ homeHandler, downloadHandler, displayAllHandler, detailsFileHander ]

const http = require('http')
http.createServer((req, res) => {
  for (let handler of handlers) {
    if (!handler(req, res)) {
      break
    }
  }
}).listen(port)
