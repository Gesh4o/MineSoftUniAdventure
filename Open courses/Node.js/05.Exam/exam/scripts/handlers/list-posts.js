const url = require('url')
const db = require('./../database')

function compare (a, b) {
  if (a.id < b.id) {
    return -1
  }
  if (a.id > b.id) {
    return 1
  }
  return 0
}


module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/all') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    res.write('<p>All posts:</p>')
    res.write('<br>')
    let sorted = db.posts.sort(compare)
    for (let post of sorted) {
      if (post.state !== 'Deleted') {
        res.write('<label>Title:</label>')
        res.write('<br>')
        res.write(`<div>${post.title}</div>`)

        res.write('<label>Content:</label>')
        res.write('<br>')
        res.write(`<div>${post.content}</div>`)
        res.write(`<a href="/details/${post.id}">Details</a>`)
        res.write('<br>')
      }
    }

    res.write('<a href="/">Home</a>')
    res.end()
  } else {
    return true
  }
}
