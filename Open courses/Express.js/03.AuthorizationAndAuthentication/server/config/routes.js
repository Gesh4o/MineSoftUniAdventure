const controllers = require('./../controllers')

module.exports = (app) => {
  app.get('/', controllers.home.index)
  app.get('/about', controllers.home.about)

  app.get('/user/register', controllers.user.registerGet)
  app.post('/user/register', controllers.user.registerPost)
  app.get('/user/login', controllers.user.loginGet)
  app.post('/user/login', controllers.user.loginPost)
  app.post('/user/logout', controllers.user.logout)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found')
    res.end()
  })
}
