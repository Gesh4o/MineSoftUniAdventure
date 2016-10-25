const Post = require('./../models/post')
const database = require('./../scripts/core/database')

module.exports.create = (postObject) => {
  let post = new Post({
    author: postObject.author,
    title: postObject.title,
    filepath: postObject.filepath,
    content: postObject.content,
    date: Date.now()
  })

  return database.savePost(post).then((postId) => {
    return postId
  })
}

module.exports.all = () => {
  return database.allPosts().then(posts => {
    return posts
  })
}

module.exports.details = (id) => {
  return database.findById(id).then((result) => {
    return result
  })
}

module.exports.delete = (id) => {
  return database.deletePost(id).then(isDeleted => {
    return isDeleted
  })
}
