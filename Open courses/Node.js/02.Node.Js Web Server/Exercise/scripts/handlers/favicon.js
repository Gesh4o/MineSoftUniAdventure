let fs = require('fs')
let url = require('url')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/favicon.ico') {
    fs.readFile('./content/favicon.ico', (err, data) => {
      if (err) {
        console.log(err)
        res.writeHead(404)
        res.end()
        return true
      }

      res.writeHead(200, {
        'Content-Type': 'favicon'
      })

      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}
