const express = require('express')
const config = require('./server/config/config')
const environment = process.env.NODE_ENV || 'develop'

const app = express()
require('./server/database')(config[environment])
require('./server/config/express')(app, config[environment])
require('./server/config/routes')(app)

app.listen(config[environment].port)
