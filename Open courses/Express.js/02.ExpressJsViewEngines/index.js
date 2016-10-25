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

app.use('/', routers.homeRouter)

app.use('/posts', routers.postRouter)

app.use(stylus.middleware({
  src: '/public',
  dest: path.join(__dirname, '/public/css/'),
  compile: (str, path) => {
    console.log(stylus(str))
    return stylus(str).set('style', path)
  }}))



// app.post('posts/update/:id', (req, res) => {
// })

// app.all('*', routers.defaultRouter)
// ToDo: Load css trough stylus.
app.listen(port)
