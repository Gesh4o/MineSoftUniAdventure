let url = require('url')
let fs = require('fs')

function getContentType (url) {
  let contentType = ''
  if (url.endsWith('.html')) {
    contentType = 'text/html'
  } else if (url.endsWith('.css')) {
    contentType = 'text/stylesheet'
  } else if (url.endsWith('.jpg') || url.endsWith('.jpeg')) {
    contentType = 'image/jpg'
  } else if (url.endsWith('.js')) {
    contentType = 'application/javascript'
  }

  return contentType
}

module.exports = (req, res) => {
  let pathName = req.pathname || url.parse(req.url).pathname
  if (pathName.startsWith('/content')) {
    let contentType = getContentType(pathName)
    if (!contentType) {
      res.writeHead(400, {'Content-Type': 'text/plain'
      })
      res.write('Invalid content type!')
      res.end()
      return
    }

    let fileName = pathName.split('/')[2]
    fs.readFile('./../Exercise/content/' + fileName, (err, data) => {
      if (err) {
        console.log(err)
        return
      }

      res.writeHead(200, {
        'Content-Type': contentType
      })

      console.log(pathName)
      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}
