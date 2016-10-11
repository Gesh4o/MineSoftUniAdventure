let url = require('url')
let fs = require('fs')
let qs = require('querystring')
let cookie = require('cookie')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/upload-image') {
    if (req.method === 'POST') {
      let dataString = ''
      req.on('data', function (chunk) {
        dataString += chunk
      })

      console.log(dataString)
      req.on('end', function () {
        let data = qs.parse(dataString)
        if (!data.name || !data.url) {
          res.writeHead(400)
          res.write('Invalid image parameters!')
          res.end()
        } else {
          let cookies = cookie.parse(req.headers.cookie || '')
          if (!cookies.images) {
            cookies.images = JSON.stringify([])
          }

          let images = JSON.parse(cookies.images)

          images.push({'name': data.name, 'url': data.url})

          res.setHeader('Set-Cookie', cookie.serialize('images', JSON.stringify(images), {
            httpOnly: true
          }))

          res.writeHead(301, {
            Location: 'http://localhost:5554/images/all'
          })
          res.end()
        }
      })
    } else {
      fs.readFile('./../Exercise/content/html/upload-image.html', (err, data) => {
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
    }
  } else {
    return true
  }
}
