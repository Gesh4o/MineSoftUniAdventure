const express = require('express')
const config = require('./config/config')
const env = process.env.NODE_ENV || 'development'
const app = express()

require('./config/express')(app, config[env])

app.listen(config[env].port)

module.exports = app
