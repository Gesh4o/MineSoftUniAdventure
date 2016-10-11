let url = require('url')
let cookie = require('cookie')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/images/all') {
    let cookies = cookie.parse(req.headers.cookie || '')
    if (!cookies.images) {
      cookies.images = JSON.stringify([])
    }

    let images = JSON.parse(cookies.images)

    let htmlString = '<ul>'
    let counter = 0

    for (let image of images) {
      htmlString +=
      '<li>' +
      'Image name: ' + image.name +
      '<br>' +
      '<a href="/images/details/' + counter + '">' +
      'Image url: ' + image.url +
      '</a>' +
      '</li>'
      counter += 1
    }

    htmlString += '</ul>' +
    '<a href="/">Back to Home Page</a>' +
    '<br>' +
    '<a href="/upload-image">Upload file</a>'

    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    res.write(htmlString)
    res.end()
  } else {
    return true
  }
}
