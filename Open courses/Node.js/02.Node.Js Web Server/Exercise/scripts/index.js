let http = require('http')
let home = require('./handlers/home')
let favicon = require('./handlers/favicon')
let staticFiles = require('./handlers/static-files')
let uploadImage = require('./handlers/upload-image')
let detailsImage = require('./handlers/details-image')
let allImages = require('./handlers/all-images')
let header = require('./handlers/header')

let modules = [ header, home, favicon, staticFiles, uploadImage, detailsImage, allImages ]

http
  .createServer((req, res) => {
    for (let module of modules) {
      if (!module(req, res)) {
        break
      }
    }
  })
  .listen(5554)
