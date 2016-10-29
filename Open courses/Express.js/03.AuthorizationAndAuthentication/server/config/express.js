const express = require('express')
const path = require('path')
const cookieParser = require('cookie-parser')
const bodyParser = require('body-parser')
const session = require('express-session')
const passport = require('passport')

module.exports = (app, config) => {
  app.use(cookieParser())
  app.use(bodyParser.urlencoded({extended: true}))
  app.use(session({secret: 's3cr3tk3y', resave: true, saveUninitialized: true}))
  app.use(passport.initialize())
  app.use(passport.session())
  app.set('view engine', 'pug')
  app.set('views', path.join(config.rootPath, 'server/views'))
  app.use((req, res, next) => {
    if (req.user) {
      res.locals.currentUser = req.user
    }

    next()
  })

  app.use(express.static('public'))
}
