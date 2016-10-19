const connectionString = 'mongodb://localhost:27017/blog-post-db'

const mongoose = require('mongoose')

mongoose.connect(connectionString)

module.exports.getLastPosts = (count) => {
}

module.exports.savePost = (postObject) => {
}

module.exports.deletePost = (id) => {
}

module.exports.updatePost = (postObject) => {
}
