const sw = require('../storage-worker')
const url = require('url')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  let fileId = req.pathname.substring(1, req.pathname.length)

  let files = sw.getStorage().files
   // console.log(sw.getStorage().files)
  if (files) {
    let index = -1
    for (let i = 0; i < files.length; i++) {
      if (files[i].key === fileId) {
        index = i
        break
      }
    }

    if (index !== -1) {
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      let file = sw.getStorage().files[index]
      res.write(`<h2>${file.value.name}</h2>`)
      res.write(`<a href=${file.value.dir.substring(1, file.value.dir.length)} download>Download</a>`)
      res.end()
    } else {
      return true
    }
  } else {
    return true
  }
}
