const url = require('url')
const db = require('./../database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname.startsWith('/details/') && req.method === 'GET') {
    let id = req.pathname.split('/')[2]
    let post = db.findByIdOrDefault(id)

    if (!post) {
      res.writeHead(404, {
        'Content-Type': 'text/html'
      })
      res.write(`<h1>Post with id: ${id} was not found!</h1>`)
      res.write('<a href="/">Home</a>')
      res.write('<br>')
      res.write('<a href="/create">Create post</a>')

      res.end()
    } else {
      let buttonName = post.state === 'Deleted' ? 'Undelete' : 'Delete'
      post.views++
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write('<label>Title:</label>')
      res.write('<br>')
      res.write(`<div>${post.title}</div>`)
      res.write('<br>')

      res.write('<label>Content:</label>')
      res.write('<br>')
      res.write(`<div>${post.content}</div>`)
      res.write('<br>')

      res.write('<label>Image:</label>')
      res.write('<br>')

      if (post.imagePath) {
        res.write(`<img src ="${post.imagePath}"></img>`)
        res.write('<br>')
      }

      res.write(`<label>Views:${post.views}</label>`)
      res.write('<br>')

      res.write(`<div>Post state: ${post.state}</div>`)
      res.write(`<form method="POST" action="${id}/state">`)
      res.write(`<button type="submit">${buttonName}</button>`)
      res.write('</form>')
      res.write('<br>')

      if (post.comments.length !== 0) {
        res.write('<label>Comments:</label>')

        for (let comment of post.comments) {
          res.write(`<div>Comment: ${comment.text}</div>`)
          res.write(`<div>By: ${comment.author}</div>`)
          res.write(`<div>On: ${comment.date}</div>`)
          res.write('<br>')
        }
      }

      res.write('<label>Add comment:</label>')
      res.write(`<form method="POST" action="${id}/comment">`)

      res.write('<input type="text" placeholder="Type comment here..." name="text">')
      res.write('<br>')
      res.write('<input type="text" placeholder="Type author here..." name="author">')
      res.write('<br>')
      res.write(`<button type="submit">Add comment</button>`)

      res.write('</form>')

      res.write('<br>')

      res.write('<a href="/">Home</a>')
      res.write('<br>')
      res.write('<a href="/all">View all posts</a>')
      res.end()
    }
  } else {
    return true
  }
}
