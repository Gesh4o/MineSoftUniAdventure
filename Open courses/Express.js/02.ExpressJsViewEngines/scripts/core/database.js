const Post = require('./../../models/post')

module.exports.getLastPosts = (count) => {
  return Post.find().then(models => {
    let array = models.sort((firstPost, secondPost) => {
      return secondPost.date - firstPost.date
    }).slice(0, count)

    return array
  })
}

module.exports.savePost = (postObject) => {
  return Post(postObject).save().then((result) => {
    return result._id
  })
}

module.exports.deletePost = (id) => {
  return Post.findByIdAndRemove(id).then(query => {
    if (query) {
      return true
    }
  })
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
