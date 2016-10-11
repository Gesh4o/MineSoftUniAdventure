const url = require('url')
const qs = require('querystring')
const db = require('./../database')

function isNullOrEmpty (value) {
  if (value === null || value === '') {
    return true
  }

  return false
}

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  let body = ''
  if (req.pathname.startsWith('/details/') &&
        req.pathname.endsWith('/comment') &&
        req.method === 'POST') {
    req.on('data', (data) => {
      body += data
    })

    req.on('end', () => {
      let comment = qs.parse(body)
      let id = req.pathname.split('/')[2]
      let post = db.findByIdOrDefault(id)

      // Post not found.
      if (!post) {
        res.writeHead(404, {
          'Content-Type': 'text/html'
        })
        res.write(`<h1>Cannot add comment to post. Post with id: ${id} was not found!</h1>`)
        res.write('<a href="/">Home</a>')
        res.write('<br>')
        res.write('<a href="/create">Create post</a>')

        res.end()
      } else {
        comment.date = new Date().toLocaleString()
        let isValid = true
        if (isNullOrEmpty(comment.text) || isNullOrEmpty(comment.author)) {
          isValid = false
        }

        // Comment not valid.
        if (!isValid) {
          res.writeHead(400, {
            'Content-Type': 'text/html'
          })
          res.write('<h1>Cannot create comment - invalid input parameters!</h1>')
          res.write('<a href="/">Home</a>')
          res.write('<br>')
          res.write(`<a href="/details/${id}">Return to post</a>`)
          res.end()
        } else {
          post.comments.push(comment)
          res.writeHead(302, {
            'Location': `details/${id}`
          })

          res.end()
        }
      }
    })
  } else {
    return true
  }
}
