const url = require('url')
const fs = require('fs')
const multiparty = require('multiparty')

const database = require('./../database')
let id = 0
let file = ''

function getNextId () {
  id += 1

  return id
}

function isNullOrEmpty (value) {
  if (value === null || value === '') {
    return true
  }

  return false
}

function writeFile (fileName, file) {
  fs.writeFile(fileName, file, 'ascii', (err) => {
    if (err) {
      throw err
    }
  })
}

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/create') {
    if (req.method === 'GET') {
      fs.readFile('./content/html/create-to-do.html', (err, data) => {
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
      let form = new multiparty.Form()
      let object = {}
      form.on('part', (part) => {
        if (part.filename) {
          file = ''
          part.setEncoding('binary')

          part.on('data', (data) => {
            file += data
          })

          part.on('end', () => {
            fs.stat('./images', (err, stats) => {
              if (err && !stats) {
                fs.mkdirSync('./images')
              }
            })
          })
        } else {
          let field = ''
          part.setEncoding('utf8')
          part.on('data', (data) => {
            field += data
          })

          part.on('end', () => {
            object[part.name] = field
          })
        }
      })

      form.on('close', () => {
        let isValid = true
        for (let fieldName in object) {
          if (object.hasOwnProperty(fieldName)) {
            if (isNullOrEmpty(object[fieldName])) {
              isValid = false
              break
            }
          }
        }

        if (isValid) {
          object.state = 'Pending'
          object.Id = getNextId()
          object.comments = []
          object.hasPicture = false
          if (file) {
            object.hasPicture = true
          }

          database.toDoEntries.push(object)

          writeFile(`./images/${object.Id}.jpg`, file)

          res.writeHead(302, {'Location': '/all'})
          res.end()
        } else {
          res.writeHead(400)
          res.write('Invalid input parameters!')
          res.write('<a href="/">Home</a>')
          res.write('<br>')
          res.write('<a href="/create">Return back to creating...</a>')

          res.end()
        }
      })

      form.parse(req)
    }
  } else {
    return true
  }
}
