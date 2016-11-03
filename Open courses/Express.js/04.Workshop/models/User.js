const mongoose = require('mongoose')
let userSchema = mongoose.Schema({
  username: {type: String, required: true, unique: true},
  passwordHash: {type: String, required: true},
  salt: {type: String, required: true},
  roles: {type: Array, default: []}
})

const User = mongoose.model('User', userSchema)

module.exports = User

