const express = require('express')
const app = express()
const routers = require('./scripts/routers/routers')
const port = 1234
const path = require('path')
const bodyParser = require('body-parser')
const stylus = require('stylus')

app.set('view engine', 'pug')
app.set('views', path.join(__dirname, 'views'))
app.use(bodyParser.urlencoded({'extended': true}))

app.use(express.static(path.join(__dirname, 'public')))
app.use(express.static(path.join(__dirname, 'uploads')))

app.use('/', routers.homeRouter)

app.use('/post', routers.postRouter)

app.use(stylus.middleware({
  src: path.join(__dirname, 'resources/'),
  dest: path.join(__dirname, 'public/'),
  compile: (str, path) => stylus(str).set('filename', path)
}))

// app.post('posts/update/:id', (req, res) => {
// })

// app.all('*', routers.defaultRouter)
app.listen(port)
