let arr = [4, 5, 10, 20, 35, 43, 5, 4]

// retorna o índice do elemento
let arrIndexOf = arr.indexOf(20) // 3, caso não encontre o valor retorna -1
let arrLastIndexOf = arr.lastIndexOf(5) // 6, caso não encontre o valor retorna -1
let arrInclude = arr.includes(20) // true, retorna true caso tenha o elemento

// retorna o primeiro valor que satisfaça a minha condição
let arrFind = arr.find(function(elemento) {
  return elemento > 10 // 20, se não encontrar retorna undefined
})

// retorna o índice do primeiro elemento encontrado que satisfaça a condição
let arrFindIndex = arr.findIndex(function(elemento) {
  return elemento > 10 // 3
})
