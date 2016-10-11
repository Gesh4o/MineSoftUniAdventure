let url = require('url')
let fs = require('fs')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/') {
    fs.readFile('./../Exercise/content/html/index.html', (err, data) => {
      if (err) {
        console.log(err)
        return
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}

