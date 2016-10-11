const url = require('url')
const fs = require('fs')
const fileHandler = require('./file-handler')

const multiparty = require('multiparty')
const form = new multiparty.Form()

const fields = {}

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/upload') {
    if (req.method === 'GET') {
      fs.readFile('./content/html/upload-file.html', (err, data) => {
        if (err) {
          throw err
        }

        res.writeHead(200, {
          'Content-Type': 'text/html'
        })

        res.write(data)
        res.end()
      })
    } else if (req.method === 'POST') {
      form.parse(req)
      form.on('part', (part) => {
        if (part.filename) {
          let file = ''
          part.setEncoding('binary')
          part.on('data', (data) => {
            file += data
          })

          part.on('end', () => {
            let extension = part.filename.substring(part.filename.lastIndexOf('.'), part.filename.length)
            part.fileName = fields.fileName || 'no-name-selected'
            fileHandler(part.fileName + extension, file)
          })
        } else {
          part.setEncoding('utf8')
          let field = ''
          part.on('data', (data) => {
            field += data
          })

          part.on('end', () => {
            fields[part.name] = field
          })
        }
      })

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write('<a href="/upload">Upload</a>')
      res.write('<br>')
      res.write('<a href="/">Back to Home</a>')

      res.end()
    }
  } else {
    return true
  }
}
