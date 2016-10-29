const mongoose = require('mongoose')
const encryption = require('./../../utilities/encryption')
const requiredValidationMessage = '{PATH} is required'

let userSchema = mongoose.Schema({
  username: {type: String, required: requiredValidationMessage, unique: true},
  firstName: {type: String, required: requiredValidationMessage},
  lastName: {type: String, required: requiredValidationMessage},
  salt: String,
  passwordHash: String,
  roles: [String]
})

userSchema.method({
  authenticate: function (password) {
    return encryption.generateHashedPassword(this.salt, password) ===
      this.passwordHash
  }
})

let User = mongoose.model('User', userSchema)
module.exports.seedAdminUser = () => {
  User.find({}).then((users) => {
    if (users.length === 0) {
      let salt = encryption.generateSalt()
      let hashedPass = encryption.generateHashedPassword(salt, 'Admin')
      User.create({
        username: 'Admin',
        firstName: 'None',
        lastName: 'None',
        salt: salt,
        passwordHash: hashedPass,
        roles: ['Admin']
      })
    }
  })
}
