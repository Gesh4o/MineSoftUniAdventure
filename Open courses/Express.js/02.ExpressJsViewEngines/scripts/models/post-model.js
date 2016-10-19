const connectionString = 'mongodb://localhost:27017/blog-post-db'

const mongoose = require('mongoose')

mongoose.connect(connectionString)

let postSchema = mongoose.Schema({
  id: Number,
  imageId: Number,
  title: String,
  author: String,
  description: String,
  date: Date
})

const Post = mongoose.model('Post', postSchema)
module.exports = Post
