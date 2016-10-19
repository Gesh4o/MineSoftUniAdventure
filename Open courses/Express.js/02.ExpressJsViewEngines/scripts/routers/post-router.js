const express = require('express')
const router = express.Router()
const postController = require('./../controllers/post-controller')
const path = require('path')

router.get('/create', (req, res) => {
  res.sendFile(path.join(__dirname, '../../private/views/post/create.html'))
})

router.post('/create', (req, res) => {
  postController.create(req.body).then((id) => {
    res.redirect(`/posts/details?id=${id.toString()}`)
  })
})

router.get('/all', (req, res) => {
  let posts = postController.all()
  res.render('post-all', posts)
})

router.get('/details?:id', (req, res) => {
  let id = req.query.id
  postController.details(id).then((post) => {
    res.render('post-details', {post})
  })
})

module.exports = router
