const multer = require('multer')
const crypto = require('crypto')

let storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, './public/images')
  },
  filename: function (req, file, cb) {
    let extension = file.originalname.substring(file.originalname.lastIndexOf('.', file.originalname))
    crypto.pseudoRandomBytes(16, (err, raw) => {
      if (err) {
        throw err
      }
      cb(null, raw.toString('hex') + Date.now() + extension)
    })
  }
})

module.exports = storage
