const express = require('express')
const router = express.Router()
const blogsCount = 6
const database = require('./../database')

router.get('/', (req, res) => {
  let posts = database.getLastPosts(blogsCount)
  console.log(posts)
  res.send('Hello, it\'s me!')
  res.end()
})

module.exports = router
