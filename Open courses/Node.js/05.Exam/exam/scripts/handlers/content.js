const url = require('url')
const fs = require('fs')

function getContentType (url) {
  let contentType = ''
  if (url.endsWith('.html')) {
    contentType = 'text/html'
  } else if (url.endsWith('.css')) {
    contentType = 'text/stylesheet'
  } else if (url.endsWith('.jpg') || url.endsWith('.jpeg')) {
    contentType = 'image/jpg'
  }

  return contentType
}

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname.startsWith('/content')) {
    fs.readFile('.' + req.pathname, (err, data) => {
      if (err) {
        res.writeHead(404, {
          'Content-Type': 'text/html'
        })

        res.write('<h1>File not found</h1>')
        res.end()
        return
      }
      let contentType = getContentType(req.pathname)

      if (!contentType) {
        res.writeHead(400, {
          'Content-Type': 'text/html'
        })

        res.write('<h1>Unrecognised file type</h1>')
        res.write('<a href="/">Home</a>')
        res.end()
      } else {
        res.writeHead(200, {
          'Content-Type': contentType
        })

        res.write(data)
        res.end()
      }
    })
  } else {
    return true
  }
}
