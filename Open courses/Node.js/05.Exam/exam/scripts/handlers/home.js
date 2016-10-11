const url = require('url')
const fs = require('fs')

const statistics = require('./statistics')
const db = require('./../database')
const wantedPostsCount = 6

function compare (a, b) {
  if (a.views < b.views) {
    return 1
  }
  if (a.views > b.views) {
    return -1
  }
  return 0
}

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/' && req.method === 'GET' && req.headers['my-authorization'] === 'Admin') {
    return statistics(req, res)
  } else if (req.pathname === '/' && req.method === 'GET') {
    fs.readFile('./content/html/index.html', (err, data) => {
      if (err) {
        throw err
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.write(data)

      let ordered = db.posts.sort(compare)
      for (let i = 0; i < wantedPostsCount; i++) {
        if (i > ordered.length) {
          break
        }
        res.write('<br>')
        res.write('<label>Title:</label>')
        res.write('<br>')
        res.write(`<div>${ordered[i].title}</div>`)

        res.write('<label>Content:</label>')
        res.write('<br>')
        res.write(`<div>${ordered[i].content}</div>`)

        res.write(`<label>Views:${ordered[i].views}</label>`)
        res.write('<br>')
      }
      res.end()
    })
  } else {
    return true
  }
}
