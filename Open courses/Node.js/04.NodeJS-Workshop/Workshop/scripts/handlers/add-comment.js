const url = require('url')
const db = require('./../database')
const qs = require('querystring')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname.startsWith('/details/') && req.pathname.endsWith('/comment') && req.method === 'POST') {
    let id = req.pathname.split('/')[2]
    let toDo = db.findById(id)

    let queryData = ''

    req.on('data', (data) => {
      queryData += data
    })

    req.on('end', () => {
      let parsedData = qs.parse(queryData)

      if (!toDo) {
        res.writeHead(404, {
          'Content-Type': 'text/html'
        })

        res.write(`<p>Canot find ToDo with id: ${id}</p>`)
        res.write('<a href="/">Home</a>')
        res.end()
      } else {
        toDo.comments.push({'text': parsedData.text, 'date': new Date().toLocaleString()})
        res.writeHead(302, {'Location': `/details/${id}`})

        res.end()
      }
    })
  } else {
    return true
  }
}
