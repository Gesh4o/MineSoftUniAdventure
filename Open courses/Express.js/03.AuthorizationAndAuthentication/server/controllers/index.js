const homeController = require('./home')
const userController = require('./user')
const articleController = require('./article')

module.exports = {
  home: homeController,
  user: userController,
  article: articleController
}
