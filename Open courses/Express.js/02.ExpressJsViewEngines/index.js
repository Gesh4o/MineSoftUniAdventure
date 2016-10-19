const express = require('express')
const app = express()
const routers = require('./scripts/routers/routers')
const port = 1234
const path = require('path')

app.set('view engine', 'pug')
app.set('views', path.join(__dirname, 'views'))

app.use('/', routers['home-router'])

// app.get('/all', (req, res) => {
// })

app.use('/posts', routers['post-router'])

// app.get('posts/details/:id', (req, res) => {
// })

// app.get('posts/update/:id', (req, res) => {
// })

// app.get('posts/delete/:id', (req, res) => {
// })

// app.post('posts/create', (req, res) => {
// })

// app.post('posts/update/:id', (req, res) => {
// })

// app.all('*', (req, res) => {
// })

app.listen(port)
