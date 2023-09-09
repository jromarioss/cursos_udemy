teste()

function teste() { // é hosting é jogado pra cima na inicialização do programa
  console.log('teste')
}

const test = function teste2() { // isso não funciona por que nao é hosting
  console.log('teste2')
}

// o hosting funciona com o var, mais não funciona com o let e const
console.log(minhaVar)
var minhaVar = 'teste 03'