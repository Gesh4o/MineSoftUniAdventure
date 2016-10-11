const url = require('url')
const fs = require('fs')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/') {
    fs.readFile('./content/html/index.html', (err, data) => {
      if (err) {
        throw err
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(data)
      res.write('<a href="/create">Create ToDo</a>')
      res.end()
    })
  } else {
    return true
  }
}
