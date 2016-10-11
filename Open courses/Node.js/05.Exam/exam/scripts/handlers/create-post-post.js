const url = require('url')
const fs = require('fs')
const multiparty = require('multiparty')

const db = require('./../database')
let file = ''

function getNextId () {
  return db.posts.length + 1
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
  req.pathname = req.pathname || url.parse(req.pathname).pathname
  if (req.pathname === '/create' && req.method === 'POST') {
    let form = new multiparty.Form()
    let post = {}
    let extension = ''
    file = ''

    form.on('part', (part) => {
      if (part.filename) {
        extension = part.filename.substring(part.filename.lastIndexOf('.'), part.filename.length)
        part.setEncoding('binary')

        part.on('data', (data) => {
          file += data
        })

        part.on('end', () => {
          fs.stat('./content/images', (err, stats) => {
            if (err && !stats) {
              fs.mkdirSync('./content/images')
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
          post[part.name] = field
        })
      }
    })

    form.on('close', () => {
      let isValid = true
      for (let fieldName in post) {
        if (post.hasOwnProperty(fieldName)) {
          if (fieldName !== 'image' && isNullOrEmpty(post[fieldName])) {
            isValid = false
            break
          }
        }
      }

      // Post not valid.
      if (!isValid) {
        res.writeHead(400, {
          'Content-Type': 'text/html'
        })

        res.write('<h1>Invalid input parameters!</h1>')
        res.write('<a href="/">Home</a>')
        res.write('<br>')
        res.write('<a href="/create">Return back to creating...</a>')

        res.end()
      } else {
        post.state = 'NotDeleted'
        post.id = getNextId()
        post.comments = []
        post.views = 0

        if (file && extension) {
          // Image not valid.
          if (extension !== '.png' || extension !== '.jpg' || extension !== '.jpeg') {
            res.writeHead(400, {
              'Content-Type': 'text/html'
            })

            res.write('<h1>Image file not valid!</h1>')
            res.write('<a href="/">Home</a>')
            res.write('<br>')
            res.write('<a href="/create">Return back to creating...</a>')

            res.end()
            return
          }

          post.imagePath = `/content/images/${post.id}${extension}`
          writeFile('.' + post.imagePath, file)
        }

        db.posts.push(post)

        res.writeHead(302, {'Location': '/create'})
        res.end()
      }
    })

    form.parse(req)
  } else {
    return true
  }
}
