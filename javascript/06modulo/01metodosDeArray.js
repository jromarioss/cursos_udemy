// array literal
const array = [1, 5, 10, "olá", true]

// retorna true caso satisfaça toda condição
let soNumero = array.every(function(elemento) {
  return typeof elemento === "number" // false
})

// cria um nova array filtrando o dados que você deseja
let filtrarNumeros = array.filter(function(elemento, indice, array) {
  return typeof elemento === "number" // [1, 5, 10]
})

// usa o forEach quando quer fazer um interação dentro do array
let foreachNumeros = array.forEach(function(elemento, indice, array) {
  // console.log(`indice: ${indice} = valor: ${elemento}`)
})

// retorna uma nova array com os dados alterados
let mapNumeros = filtrarNumeros.map(function(elemento, indice, array) {
  return elemento * elemento // 1, 25, 100
})