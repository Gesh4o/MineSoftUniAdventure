const crypto = require('crypto')

module.exports = {
  generateSalt: () => {
    let salt = crypto.randomBytes(128).toString('base64')
    return salt
  },

  getPasswordHash: (salt, password) => {
    let passwordHash = crypto.createHmac('sha256', salt).update(password).digest('hex')
    return passwordHash
  }
}
