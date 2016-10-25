const connectionString = 'mongodb://localhost:27017/blog-post-db'

const mongoose = require('mongoose')
mongoose.Promise = global.Promise
mongoose.connect(connectionString)

let postSchema = mongoose.Schema({
  title: String,
  author: String,
  filepath: String,
  content: String,
  date: Date
})

const Post = mongoose.model('Post', postSchema)
module.exports = Post
