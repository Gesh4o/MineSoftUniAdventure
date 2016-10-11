const home = require('./home')
const createPostPost = require('./create-post-post')
const createPostGet = require('./create-post-get')
const allPosts = require('./list-posts')
const detailsPost = require('./details-post')
const updatePostState = require('./update-post-state')
const createComment = require('./create-comment')
const content = require('./content')

module.exports = [ home, createPostGet, createPostPost, allPosts, detailsPost, updatePostState, createComment, content ]
