const connectionString = 'mongodb://localhost:27017/blog-post-db'

const mongoose = require('mongoose')
mongoose.Promise = global.Promise
mongoose.connect(connectionString)

let postSchema = mongoose.Schema({
  imageId: Number,
  title: String,
  author: String,
  content: String,
  date: Date
})

const Post = mongoose.model('Post', postSchema)
module.exports = Post
