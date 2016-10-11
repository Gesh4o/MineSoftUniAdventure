const sw = require('../storage-worker')
const url = require('url')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/display-all') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    res.write('<h1>List all files</h1>')
    if (sw.getStorage().files) {
      for (let file of sw.getStorage().files) {
        console.log(file)
        res.write(`<a href=${file.key}>${file.value.name}</a>`)
        res.write('<br>')
      }
    }

    res.write('<a href="/upload">Upload</a>')
    res.write('<br>')
    res.write('<a href="/">Home</a>')

    res.end()
  } else {
    return true
  }
}
