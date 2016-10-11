let http = require('http')

http
  .createServer((req, res) => {
    res.writeHead(200)
    res.write('Hi!')
    res.end()
  })
.listen(1337)
