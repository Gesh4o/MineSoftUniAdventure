const express = require('express')
const router = express.Router()
const postController = require('./../../controllers/post')
const multer = require('multer')
const storage = require('./../multer-storage')

const upload = multer({storage: storage})

router.get('/create', (req, res) => {
  res.render('post/create')
})

router.post('/create', upload.single('photo'), (req, res) => {
  let postObject = req.body

  if (req.file) {
    let filepath = req.file.path.substring(req.file.path.indexOf('\\') + 1, req.file.path.lenght)
    postObject.filepath = filepath
  } else {
    postObject.filepath = ''
  }

  postController.create(postObject).then((id) => {
    res.redirect(`/post/details?id=${id.toString()}`)
  })
})

router.get('/all', (req, res) => {
  postController.all().then(posts => {
    res.render('post/all', {posts})
  })
})

router.get('/details?:id', (req, res) => {
  let id = req.query.id
  postController.details(id).then((post) => {
    res.render('post/details', {post})
  })
})

router.get('/delete?:id', (req, res) => {
  let id = req.query.id
  postController.delete(id).then(isDeleted => {
    if (isDeleted) {
      res.redirect('/all')
    } else {
      res.render('post/delete-error', {id})
    }
  })
})

module.exports = router
