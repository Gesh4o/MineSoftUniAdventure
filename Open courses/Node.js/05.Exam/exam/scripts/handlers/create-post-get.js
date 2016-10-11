const url = require('url')
const fs = require('fs')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.pathname).pathname

  if (req.pathname === '/create' && req.method === 'GET') {
    fs.readFile('./content/html/create-post.html', (err, data) => {
      if (err) {
        throw err
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.write(data)
      res.write('<br>')
      res.write('<a href="/">Home</a>')
      res.write('<br>')
      res.write('<a href="/all">View all posts</a>')
      res.end()
    })
  } else {
    return true
  }
}
