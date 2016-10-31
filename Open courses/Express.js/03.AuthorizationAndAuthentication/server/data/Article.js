const mongoose = require('mongoose')

const articleSchema = mongoose.Schema({
  title: { type: String, required: true },
  description: { type: String, required: true },
  author: { type: String, required: true },
  date: { type: Date, default: Date.now() }
})

const model = mongoose.model('Article', articleSchema)

module.exports = model
