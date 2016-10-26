const express = require('express')
const path = require('path')

module.exports = (app, config) => {
  app.use(express.static('public'))

  app.set('view engine', 'pug')
  app.set('views', path.join(config.rootPath, 'views'))

  console.log('Exress ready!')
}
