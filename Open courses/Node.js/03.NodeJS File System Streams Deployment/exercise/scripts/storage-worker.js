const db = require('./json-storage')

function addFile (key, value) {
  if (!db.files) {
    db.files = []
  }

  db.files.push({'key': key, 'value': value})

  db.saveDbTo(db)
}

function getStorage () {
  if (!db.files) {
    db.files = []
    db.saveDbTo(db)
  }

  return db.getDb()
}

module.exports = { 'addFile': addFile, 'getStorage': getStorage }
