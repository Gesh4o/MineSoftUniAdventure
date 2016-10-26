const express = require('express')
const mongoose = require('mongoose')
const connectionString = 'mongodb://localhost:27017/articles-and-posts'

mongoose.Promise = global.Promise
const app = express()
const port = 1234


app.get('/', (req, res) => {
  console.log('Exress ready!')
  mongoose.connect(connectionString).then(() => {
    console.log('MongoDB ready!')
  })

  res.send('Hello')
})

app.listen(port)
