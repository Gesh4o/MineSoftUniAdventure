const User = require('mongoose').model('User')
const encryption = require('./utilities/encryption')
module.exports = {
  loginGet: (req, res) => {
    res.render('user/login')
  },

  loginPost: (req, res) => {
    let params = req.body
    params.salt = encryption.generateSalt()
    User.find({username: params.username}).then(users => {
      let error = ''
      if (users.length > 0) {
        error = 'User with that name exists!'
      } else if (params.password !== params.repeatedPassword) {
        error = 'Passwords do not match!'
      }

      if (error) {
        res.redirect('user/login', {error: error, params})
        return
      }

      User.create(params).then(user => {
        // If db throws error upon creating?
        req.logIn(user)
        res.locals.user = user
        res.redirect('/', {user: user})
      })
    })
  }
}
