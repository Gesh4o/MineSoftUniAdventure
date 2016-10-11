const url = require('url')
const db = require('./../database')
const addComment = require('./add-comment')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname.startsWith('/details/')) {
    if (req.pathname.endsWith('/comment')) {
      return addComment(req, res)
    }
    let id = req.pathname.split('/')[2]

    let toDo = db.findById(id)

    if (!toDo) {
      res.writeHead(404, {
        'Content-Type': 'text/html'
      })
      res.write(`<p>Canot find element with id: ${id}</p>`)
      res.write('<a href="/">Home</a>')

      res.end()
    } else {
      let buttonState = toDo.state === 'Pending' ? 'Done' : 'Pending'
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(`<div>Title:</div>
      <div>${toDo.name}</div>
      <div>Description:</div>
      <div>${toDo.description}</div>
      <div>State:</div>
      <div>${toDo.state}</div>
      <form>
      <button value="${buttonState}" formaction="/update/${+id}" type="submit">${buttonState}</button>
      </form>`)

      res.write('<div>Comments:</div>')
      res.write('<br>')
      for (let comment of toDo.comments) {
        res.write(`<div>Text:${comment.text}</div>`)
        res.write(`<div>Date of comment: ${comment.date}</div>`)
      }

      if (toDo.hasPicture) {
        res.write(`<img src="/images/${+id}.jpg"><br>`)
      }

      res.write('<br>')
      res.write('<form method="POST">')
      res.write('<input name="text" type="text" placeholder"Add comment here.."></input>')
      res.write(`<input type="submit" formaction="/details/${+id}/comment" value="Add comment"></input>`)
      res.write('</form>')
      res.write('<a href="/">Home</a>')
      res.write('<br>')
      res.write('<a href="/all">All to-do</a>')

      res.end()
    }
  } else {
    return true
  }
}
