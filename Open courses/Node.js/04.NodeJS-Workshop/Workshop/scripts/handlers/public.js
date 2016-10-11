const url = require('url')
const fs = require('fs')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname.startsWith('/images')) {
    fs.readFile('.' + req.pathname, (err, data) => {
      if (err) {
        return true
      }

      res.writeHead(200, {
        'Content-Type': 'image/jpeg'
      })
      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}
