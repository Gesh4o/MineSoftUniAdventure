const Tag = require('./modules/tag')
const Image = require('./modules/image')

module.exports.saveImage = (image) => {
  for (let tag of image.tags) {
    this.saveTag(tag)
  }

  new Image({
    url: image.url,
    description: image.description,
    creationDate: Date.now(),
    tags: []
  }).save().then((img) => {
    console.log(img)
    for (let tag of image.tags) {
      let wholeTag = Tag.findOne({'name': tag})
      img.tags.push(wholeTag)
    }

    console.log(img)
    img.save()
  })
}

module.exports.saveTag = (tag) => {
  new Tag({
    name: tag.name,
    creationDate: Date.now(),
    images: tag.images || []
  }).save().then()
}
