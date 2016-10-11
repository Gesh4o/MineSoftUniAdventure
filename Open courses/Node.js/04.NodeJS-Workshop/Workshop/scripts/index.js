const port = 1234

const home = require('./handlers/home')
const createToDo = require('./handlers/create-to-do')
const listTodo = require('./handlers/list-to-do')
const updateToDo = require('./handlers/update-to-do')
const detailsToDo = require('./handlers/details-to-do')
const pub = require('./handlers/public')
const statistics = require('./handlers/statistics')

const handlers = [ pub, statistics, home, createToDo, listTodo, detailsToDo, updateToDo ]

const http = require('http')
http.createServer((req, res) => {
  for (let handler of handlers) {
    if (!handler(req, res)) {
      break
    }
  }
}).listen(port)
