const express = require('express')
const router = express.Router()

router.all('*', (err, req, res) => {
  if (err) {
    console.log(err.statusMessage)
  }

  // res.send('Source not found. Go back to home.')
  res.end()
})

module.exports = router
