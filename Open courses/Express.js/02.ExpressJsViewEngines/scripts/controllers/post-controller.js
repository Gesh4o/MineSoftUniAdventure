const Post = require('./../models/post-model')
const database = require('./../database')
let imageId = 1

module.exports.create = (postObject) => {
  let post = new Post({
    imageId: imageId,
    author: postObject.author,
    title: postObject.title,
    content: postObject.content,
    date: Date.now()
  })

  imageId += 1
  return database.savePost(post).then((postId) => {
    return postId
  })
}

module.exports.all = () => {
  return database.allPosts()
}

module.exports.details = (id) => {
  return database.findById(id).then((result) => {
    return result
  })
}
