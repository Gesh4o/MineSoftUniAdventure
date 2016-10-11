const url = require('url')
const db = require('./../database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/' && req.method === 'GET' &&
      req.headers['my-authorization'] === 'Admin') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    let totalComments = 0
    let totalViews = 0
    for (let post of db.posts) {
      let buttonName = post.state === 'Deleted' ? 'Undelete' : 'Delete'
      res.write(`<a href="/details/${post.id}">${post.title}</a>`)
      res.write('<br>')

      res.write('<label>Content:</label>')
      res.write('<br>')
      res.write(`<div>${post.content}</div>`)
      res.write('<br>')

      res.write(`<label>Views:${post.views}</label>`)
      res.write('<br>')

      res.write(`<div>Post state: ${post.state}</div>`)
      res.write(`<form method="POST" action="${post.id}/state">`)
      res.write(`<button type="submit">${buttonName}</button>`)
      res.write('</form>')
      res.write('<br>')

      totalComments += post.comments.length
      totalViews += post.views
    }

    res.write(`<label>Total views: ${totalViews}</label>`)
    res.write('<br>')
    res.write(`<label>Total comments: ${totalComments}</label>`)
    res.end()
  } else {
    return true
  }
}
