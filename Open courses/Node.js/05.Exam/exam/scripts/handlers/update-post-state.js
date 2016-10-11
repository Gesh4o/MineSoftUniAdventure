const url = require('url')
const db = require('./../database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname.startsWith('/details/') &&
      req.pathname.endsWith('/state') &&
      req.method === 'POST') {
    // Expected url: details/id/state
    let id = req.pathname.split('/')[2]
    let post = db.findByIdOrDefault(id)
    if (!post) {
      res.writeHead(404, {
        'Content-Type': 'text/html'
      })
      res.write(`<h1>Cannot update post with id: ${id} - post was not found!</h1>`)
      res.write('<a href="/">Home</a>')
      res.write('<br>')
      res.write('<a href="/create">Create post</a>')

      res.end()
    } else {
      post.state = post.state === 'Deleted' ? 'NotDeleted' : 'Deleted'

      let location = `/details/${post.id}`
      res.writeHead(302, {
        'Location': location
      })

      res.end()
    }
  } else {
    return true
  }
}
