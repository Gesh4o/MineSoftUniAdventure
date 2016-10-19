const homeRouter = require('./home')
const postRouter = require('./post')
const defaultRouter = require('./default')

module.exports = { 'homeRouter': homeRouter,
                   'postRouter': postRouter,
                   'defaultRouter': defaultRouter }
