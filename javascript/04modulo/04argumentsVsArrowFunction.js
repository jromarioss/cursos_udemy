const somar = function() { // o arguments não funciona com () =>
  let total = 0
  for (let i = 0; i < arguments.length; i++) {
    total += arguments[i]
  }
  return total
}
console.log(somar(3, 4, 5, 9, 50)) // 71