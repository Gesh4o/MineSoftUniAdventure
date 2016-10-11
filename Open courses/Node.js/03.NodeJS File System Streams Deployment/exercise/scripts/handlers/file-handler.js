const fs = require('fs')
const Guid = require('guid')
const fileGiud = Guid.create()
const sw = require('../storage-worker')

const baseDirectoryPath = './content/uploads/'
const maxCapacity = 2

function writeFile (fileName, file) {
  fs.writeFile(fileName, file, 'ascii', (err) => {
    if (err) {
      throw err
    }
  })
}

module.exports = (fileName, file) => {
  let extension = fileName.substring(fileName.lastIndexOf('.'), fileName.Length)

  if (!fs.existsSync(baseDirectoryPath)) {
    fs.mkdirSync(baseDirectoryPath)
  }

  fs.readdir(baseDirectoryPath, (err, dirNames) => {
    if (err) {
      throw err
    }

    dirNames.filter((dir) => {
      return fs.statSync(baseDirectoryPath + dir).isDirectory()
    })

    let isFound = false
    for (let dir of dirNames) {
      let fileNames = fs.readdirSync(baseDirectoryPath + dir)
      if (fileNames) {
        fileNames.filter((f) => {
          return fs.statSync(baseDirectoryPath + dir + '/' + f).isFile()
        })

        if (fileNames.length < maxCapacity) {
          isFound = true

          // Save file to current folder.
          let wholeDir = baseDirectoryPath + dir + '/' + fileGiud + extension
          writeFile(wholeDir, file)

          // Save entity to storage.
          sw.addFile(fileGiud.value, {'dir': wholeDir, 'name': fileName.substring(0, fileName.lastIndexOf('.'))})
        }
      }

      if (isFound) {
        break
      }
    }

    if (!isFound) {
      // Create another folder.
      let folderGuid = Guid.create()
      let folderDir = baseDirectoryPath + folderGuid.value

      fs.mkdir(folderDir, (err) => {
        if (err) {
          throw err
        }

        let wholeDir = folderDir + '/' + fileGiud + extension
        writeFile(wholeDir, file)

        // Save entity to storage.
        sw.addFile(fileGiud.value, {'dir': wholeDir, 'name': fileName.substring(0, fileName.lastIndexOf('.'))})
      })
    }
  })
}
