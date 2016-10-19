const express = require('express')
const router = express.Router()
const postController = require('./../controllers/post-controller')
const path = require('path')

router.get('/create', (req, res) => {
  res.sendFile(path.join(__dirname, '../../private/views/post/create.html'))
})

router.post('/create', (req, res) => {
  postController.create()
  res.end()
})

module.exports = router
