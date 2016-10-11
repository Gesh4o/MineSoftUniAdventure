const toDoEntries = []

function findById (id) {
  let toDo = null

  for (let toDoEntry of toDoEntries) {
    if (toDoEntry.Id === +id) {
      toDo = toDoEntry
      break
    }
  }

  return toDo
}

module.exports = {'toDoEntries': toDoEntries, 'findById': findById}
