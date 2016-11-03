
const database = require('./database')
const path = require('path')
const express = require('express')
const controllers = require('./../controllers')

module.exports = (app, config) => {
  app.set('view engine', 'pug')
  app.set('views', path.normalize(path.join(__dirname, '/../views')))
  app.use(express.static('public'))

  database(config)

  app.get('/', controllers.home.index)
  app.get('/user/login', controllers.user.loginGet)
}
