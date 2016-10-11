const posts = [
  JSON.parse(
    '{"title":"Pesho","content":"...","state":"NotDeleted","id":1,"comments":[],"views":0}'),
  JSON.parse(
    '{"title":"Gosho","content":"Mnogo text","state":"NotDeleted","id":1,"comments":[],"views":12}'),
  JSON.parse(
    '{"title":"Misho","content":"Text","state":"NotDeleted","id":1,"comments":[],"views":3}'),
  JSON.parse(
    '{"title":"Tosho","content":"12321351343","state":"NotDeleted","id":1,"comments":[],"views":40}'),
  JSON.parse(
    '{"title":"Moro","content":"Sample","state":"NotDeleted","id":1,"comments":[],"views":1}'),
  JSON.parse(
    '{"title":"Ginka","content":"Sample data","state":"NotDeleted","id":1,"comments":[],"views":2}') ]

function findByIdOrDefault (id) {
  let post = null
  for (let p of posts) {
    if (p.id === +id) {
      post = p
      break
    }
  }

  return post
}

module.exports = { 'posts': posts, 'findByIdOrDefault': findByIdOrDefault }
