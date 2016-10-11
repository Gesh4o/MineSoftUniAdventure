const url = require('url')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    res.write('<h1>Hi, welcome to my website!</h1>')
    res.write('<a href="/upload">Upload</a>')
    res.write('<br>')
    res.write('<a href="/display-all">Show all files</a>')

    res.end()
  } else {
    return true
  }
}
