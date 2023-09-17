const numeros = [1, 3, 4, 1, 4, 5, 3, 5, 8, 9]
// retorno [1, 3, 4, 5, 8, 9]

let numerosUnicos = numeros.reduce((acc, atual) => {

  if (acc.indexOf(atual) < 0) {
    acc.push(atual)
  }

  return acc
}, [])

console.log("números únicos = ", numerosUnicos); // [1, 3, 4, 5, 8, 9]