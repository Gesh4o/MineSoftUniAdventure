const Post = require('./models/post-model')

module.exports.getLastPosts = (count) => {
  return []
}

module.exports.savePost = (postObject) => {
  return Post(postObject).save().then((result) => {
    return result._id
  })
}

module.exports.deletePost = (id) => {
}

module.exports.updatePost = (postObject) => {
  Post.findByIdAndUpdate(postObject.id, {
    $set: {
      title: postObject.title,
      content: postObject.content,
      author: postObject.author}
  })
}

module.exports.allPosts = () => {
  return Post.find().then((posts) => {
    return posts
  })
}

module.exports.findById = (id) => {
  return Post.findById(id).then((result) => {
    return result
  })
}
