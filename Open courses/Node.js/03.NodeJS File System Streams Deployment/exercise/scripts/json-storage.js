const fs = require('fs')

function initDb () {
  // let writeStream = fs.createWriteStream('./storage.json')
  // writeStream.write(JSON.stringify({ 'files': [] }))
  // writeStream.end()

  saveDbTo({ 'files': [] })
}

function getDb () {
  let isExisting = fs.existsSync('./storage.json')
  if (!isExisting) {
    initDb()
  } else {
    let data = fs.readFileSync('./storage.json', 'utf8')

    // console.log(data)
    if (!data) {
      initDb()
    } else {
      this.files = JSON.parse(data).files
    }
  }

  return this
}

function saveDbTo (data) {
  fs.writeFileSync('./storage.json', JSON.stringify(data), {'flags': 'w'})

  // Concurency not made properly.
  // let writeStream = fs.createWriteStream(path, { 'flags': 'w' })
  // writeStream.write(JSON.stringify(data))
  // writeStream.end()
}

module.exports = { 'getDb': getDb, 'saveDbTo': saveDbTo, 'initDb': initDb }
