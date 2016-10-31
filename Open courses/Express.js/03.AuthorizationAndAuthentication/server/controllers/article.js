const auth = require('./../config/auth')
const Article = require('mongoose').model('Article')

module.exports = {
  addGet: (req, res) => {
    auth.isAuthenticated(req, res, (req, res) => {
      res.render('article/add')
    })
  },

  addPost: (req, res) => {
    let reqBody = req.body
    reqBody.author = res.locals.currentUser.username
    Article.create(reqBody).then(article => {
      res.redirect(`/article/details/${article._id}`)
    })
  },

  details: (req, res) => {
    let id = req.params.id
    Article.findOne({_id: id}).then(art => {
      res.render('article/details', {article: art})
    })
  },

  editGet: (req, res) => {
    let id = req.params.id
    Article.findOne({_id: id}).then(article => {
      res.render('article/edit', {article: article})
    })
  },

  editPost: (req, res) => {
    let id = req.params.id
    let reqBody = req.body

    Article.update({_id: id}, {title: reqBody.title, description: reqBody.description}).then(article => {
      res.redirect(`/article/details/${id}`)
    })
  },

  all: (req, res) => {
    Article.find({}).then(articles => {
      res.render('article/all', {articles: articles})
    })
  }
}
