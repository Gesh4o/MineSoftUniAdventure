const mongoose = require('mongoose')
mongoose.Promise = global.Promise

const tagSchema = new mongoose.Schema({
  name: String,
  creationDate: Date,
  images: []
})

const Tag = mongoose.model('Tag', tagSchema)
module.exports = Tag
