const express = require('express')
const app = express()
const handlers = require('./scripts/handlers/handlers')
const port = 1234

app.use('/', handlers['home-handler'])

app.get('/all', (req, res) => {
})

app.get('posts/create', (req, res) => {
})

app.get('posts/details/:id', (req, res) => {
})

app.get('posts/update/:id', (req, res) => {
})

app.get('posts/delete/:id', (req, res) => {
})

app.post('posts/create', (req, res) => {
})

app.post('posts/update/:id', (req, res) => {
})

app.all('*', (req, res) => {
})

app.listen(port)
