const url = require('url')
const db = require('./../database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.parse).url
  // console.log(req.headers)
  if (req.pathname === '/' && req.method === 'GET' && req.headers['my-authorization'] === 'MyAdmin') {
    res.writeHead(200, {
      'Content-Type': 'text/html'
    })

    let count = 0
    for (let toDo of db.toDoEntries) {
      count += toDo.comments.length
    }

    res.write(`<div>ToDo's count: ${db.toDoEntries.length}</div>`)
    res.write(`<div>Comments's count: ${count}</div>`)
    res.end()
  } else {
    return true
  }
}
