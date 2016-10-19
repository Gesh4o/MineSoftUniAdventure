const Post = require('./../models/post-model')
const database = require('./../database')
let id = 1
let imageId = 1

module.exports.create = (postObject) => {
  let post = new Post({
    id: id,
    imageId: imageId,
    title: post.title,
    description: post.description,
    date: Date.now()
  })

  database.savePost(post)
  id += 1
  imageId += 1
}
