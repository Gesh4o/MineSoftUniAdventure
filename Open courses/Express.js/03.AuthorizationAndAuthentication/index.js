const express = require('express')
const mongoose = require('mongoose')
const connectionString = 'mongodb://localhost:27017/articles-and-posts'

mongoose.Promise = global.Promise
const app = express()

const port = process.env.port || 1234
const environment = process.env.NODE_ENV || 'develop'

app.set('view engine', 'pug')
app.set('views', 'views')

app.use(express.static('public'))

app.get('/', (req, res) => {
  console.log('Exress ready!')
  mongoose.connect(connectionString).then(() => {
    console.log('MongoDB ready!')
  })

  res.render('index')
})

app.listen(port)
