const express = require('express')
const app = express()
const routers = require('./scripts/routers/routers')
const port = 1234
const path = require('path')
const bodyParser = require('body-parser')

app.set('view engine', 'pug')
app.set('views', path.join(__dirname, 'views'))
app.use(bodyParser.urlencoded({'extended': true}))

app.use('/', routers.homeRouter)

app.use('/posts', routers.postRouter)

// app.post('posts/update/:id', (req, res) => {
// })

// app.all('*', routers.defaultRouter)
// ToDo: Load css trough stylus.
app.listen(port)
