let fs = require('fs')
let ejs = require('ejs')
let cookie = require('cookie')

module.exports = (req, res) => {
  if (req.headers.name && req.headers.value) {
    if (req.headers.name === 'StatusHeader' && req.headers.value === 'Full') {
      fs.readFile('./../Exercise/content/html/header.html', 'utf-8', (err, data) => {
        if (err) {
          console.log(err)
        }

        let cookies = cookie.parse(req.headers.cookie || '')
        let images = JSON.parse(cookies.images)
        let count = images.length

        res.writeHead(200, {
          'Content-Type': 'text/html'
        })

        let renderedHtml = ejs.render(data, {count: count})
        res.end(renderedHtml)
      })
    }
  } else {
    return true
  }
}
