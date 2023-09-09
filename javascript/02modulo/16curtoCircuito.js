let n = 0

n = n || 10 // por zero ser falso ele mostra o 10

console.log(n) // 10

let isValid = false

isValid && console.log('é valido') // não executa
isValid || console.log('é valido') // executa é valido