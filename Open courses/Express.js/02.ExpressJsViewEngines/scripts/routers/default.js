const express = require('express')
const router = express.Router()

router.all('*', (req, res) => {
  res.send('Source not found. Go back to home.')
})

module.exports = router
