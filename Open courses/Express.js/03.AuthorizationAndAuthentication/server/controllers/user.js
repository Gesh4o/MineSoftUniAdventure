const encryption = './utilities/encryption'
const User = require('mongoose').model('User')

module.exports = {
  registerGet: (req, res) => {
    res.render('user/register')
  },

  registerPost: (req, res) => {
    let user = req.body
    user.salt = encryption.generateSalt()
    user.hashedPass = encryption.generateHashedPassword(user.salt,
    user.passwd)
    User.create(user).then(user => {
      req
     .logIn(user, (err, user) => {
       if (err) {
         user.globalError = err
         res.render('user/register', user)
       }

       res.redirect('/')
     })
    })
  },

  loginGet: (req, res) => {
    res.render('user/login')
  },

  loginPost: (req, res) => {
    let user = req.body
    User.findOne({username: user.username}).then((user) => {
      if (!user) {
        res.render('user/login', { globalError: 'Invalid username or password' })
        return
      }

      let userSalt = user.salt
      let passwordHash = user.passwordHash
      let reqPasswordHash = encryption.generateHashedPassword(userSalt, user.password)

      if (reqPasswordHash !== passwordHash) {
        res.render('user/login', { globalError: 'Invalid username or password' })
        return
      }

      req.logIn(user, (err, user) => {
        if (err) {
          console.log(err)
          res.redirect('/')
        }
      })
    })
  },

  logout: (req, res) => {
    req.logout()
    res.redirect('/')
  }
}
