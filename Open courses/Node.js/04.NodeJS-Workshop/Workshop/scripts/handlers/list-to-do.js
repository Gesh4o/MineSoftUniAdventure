const url = require('url')
const database = require('./../database')

// 1:40
module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/all') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    for (let toDo of database.toDoEntries) {
      res.write(`<div>Title:</div>
                <div>${toDo.name}</div>
                <div>Description:</div>
                <div>${toDo.description}</div>
                <div>Status:</div>
                <div>${toDo.state}</div>
                <a href="/details/${toDo.Id}">Details</a>
                <br>`)
    }

    res.write('<a href="/create">Create</a>')
    res.write('<br>')
    res.write('<a href="/">Home</a>')
    res.end()
  } else {
    return true
  }
}
