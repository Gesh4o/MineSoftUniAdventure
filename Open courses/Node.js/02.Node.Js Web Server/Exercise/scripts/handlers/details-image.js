let url = require('url')
let cookie = require('cookie')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname.startsWith('/images/details/')) {
    let imageId = req.pathname.split('/')[3]

    let cookies = cookie.parse(req.headers.cookie || '')
    let images = JSON.parse(cookies.images)

    let counter = 0
    let name = ''
    let url = ''
    for (let image of images) {
      if (counter === +imageId) {
        name = image.name
        url = image.url
        break
      }

      counter += 1
    }

    if (name && url) {
      let htmlString =
      '<div>' +
      name +
      '</div>' +
      '<img src="' +
      url +
      '">' +
      '</img>'

      htmlString += '<br>' +
    '</ul>' +
    '<a href="/">To Home Page</a>' +
    '<br>' +
    '<a href="/upload-image">Upload file</a>' +
    '<br>' +
    '<a href="/images/all">Back to all images</a>'

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(htmlString)
      res.end()
    } else {
      res.writeHead(400, {
        'Content-Type': 'text/plain'
      })

      res.write('Image not found!')
      res.end()
    }
  } else {
    return true
  }
}
