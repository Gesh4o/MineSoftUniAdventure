
const database = require('./database')
const path = require('path')
const express = require('express')
const controllers = require('./../controllers')
const cookieParser = require('cookie-parser')
const bodyParser = require('body-parser')
const session = require('express-session')
const passport = require('passport')


module.exports = (app, config) => {
  app.set('view engine', 'pug')
  app.set('views', path.normalize(path.join(__dirname, '/../views')))
  app.use(express.static('public'))

  // Used to parse form data.
  app.use(bodyParser.urlencoded({extended: true}))

  // Saves cookie information.
  app.use(cookieParser())

  // Initialize session.
  app.use(session({
    secret: 't0p-s3cr3t!!1',
    resave: false,
    saveUninitialized: false }))

  // Initialize security session.
  app.use(passport.initialize())
  app.use(passport.session())

  // Save current user into locals storage.
  app.use((req, res, next) => {
    if (req.user) {
      res.locals.currentUser = req.user
    }

    next()
  })


  database(config)

  app.get('/', controllers.home.index)
  app.get('/user/register', controllers.user.registerGet)
  app.post('/user/register', controllers.user.registerPost)
  app.get('/user/login', controllers.user.loginGet)
  app.post('/user/login', controllers.user.loginPost)
  app.get('/user/logout', controllers.user.logout)
}
