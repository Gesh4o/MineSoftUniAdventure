const User = require('mongoose').model('User')
const encryption = require('./../utilities/encryption')
module.exports = {
  registerGet: (req, res) => {
    res.render('user/register')
  },

  registerPost: (req, res) => {
    let params = req.body

    User.find({username: params.username}).then(users => {
      let error = ''
      if (users.length > 0) {
        error = 'User with that name exists!'
      } else if (params.password !== params.repeatedPassword) {
        error = 'Passwords do not match!'
      }

      if (error) {
        res.redirect('/user/register', {error: error, params})
        res.end()
      }

      let salt = encryption.generateSalt()
      let currentUser = {
        username: params.username,
        passwordHash: encryption.getPasswordHash(salt, params.password),
        salt: salt
      }

      User.create(currentUser).then(user => {
        // If db throws error upon creating?
        req.logIn(user, (err, user) => {
          if (err) {
            // ToDo: You can either send it as a message or simply ignore it.
          }

          res.redirect('/', {user: user})
        })
      })
    })
  },

  loginGet: (req, res) => {
    res.render('/user/login')
  },

  loginPost: (req, res) => {

  },

  logout: (req, res) => {
    req.logout()
    res.redirect('/')
  }
}
