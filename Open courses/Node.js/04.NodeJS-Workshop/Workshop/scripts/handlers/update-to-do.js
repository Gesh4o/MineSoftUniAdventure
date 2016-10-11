const url = require('url')
const db = require('./../database')
const states = ['Done', 'Pending']

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname.startsWith('/update/')) {
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
      if (toDo.state === states[0]) {
        toDo.state = states[1]
        res.writeHead(302, {'Location': `/details/${id}`})

        res.end()
      } else if (toDo.state === states[1]) {
        toDo.state = states[0]
        res.writeHead(302, {'Location': `/details/${id}`})

        res.end()
      } else {
        res.writeHead(404, {
          'Content-Type': 'text/html'
        })
        res.write(`<p>Invalid state: ${toDo.state}</p>`)
        res.write('<a href="/">Home</a>')

        res.end()
      }
    }
  } else {
    return true
  }
}
