// o js não é estritamente tipado

let x = 10
x = 'outra string'
console.log('outra string')

function teste() {
  console.lot(this) // é o obj windows
}
teste()