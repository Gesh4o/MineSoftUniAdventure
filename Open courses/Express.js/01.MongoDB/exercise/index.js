const instanodeDb = require('./instanode-db')

const mongoose = require('mongoose')
const connection = 'mongodb://localhost:27017/intro'

mongoose.connect(connection).then((db) => {
  instanodeDb.saveImage({ url: 'https://i.ytimg.com/vi/tntOCGkgt98/maxresdefault.jpg', description: 'such cat much wow', tags: ['cat', 'kitty', 'cute', 'catstagram'] })
})
