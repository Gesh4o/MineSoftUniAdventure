const express = require('express')
const router = express.Router()
const blogsCount = 6
const database = require('./../core/database')

router.get('/', (req, res) => {
  database.getLastPosts(blogsCount).then(posts => {
    res.render('home', {posts})
  })
})

module.exports = router
