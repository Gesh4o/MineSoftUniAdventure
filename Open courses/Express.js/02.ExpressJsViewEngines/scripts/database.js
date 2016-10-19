const Post = require('./models/post-model')

module.exports.getLastPosts = (count) => {
  return []
}

module.exports.savePost = (postObject) => {
}

module.exports.deletePost = (id) => {
}

module.exports.updatePost = (postObject) => {
  Post(postObject).save().then((result) => {
    console.log(result)
  })
}
