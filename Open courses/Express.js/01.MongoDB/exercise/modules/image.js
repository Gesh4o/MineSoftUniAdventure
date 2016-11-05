const mongoose = require('mongoose')
mongoose.Promise = global.Promise

const Tag = require('./tag')

const imageSchema = new mongoose.Schema({
  url: String,
  description: String,
  creationDate: Date,
  tags: [Tag.schema]

})

const Image = mongoose.model('Image', imageSchema)

module.exports = Image
