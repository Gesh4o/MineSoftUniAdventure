const mongoose = require('mongoose')

module.exports = (config) => {
  mongoose.connect(config.connectionString)

  let db = mongoose.connection

  db.on('error', err => {
    console.log('Error in database: ' + err)
  })

  db.once('open', err => {
    if (err) {
      console.log(err)
      return
    }

    console.log('MongoDB ready!')
  })
}

require('./../models/User')
