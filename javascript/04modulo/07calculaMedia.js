(function() {
  function calculaMedia() {
    let total = 0
    let qtd = arguments.length // quantos parâmetros tem

    for (let i = 0; i < qtd; i++) {
      if (typeof arguments[i] !== 'number') {
        throw Error('only numbers')
      }

      total += arguments[i]
    }

    return total / qtd
  }

  let media1 = calculaMedia(6, 8)
  let media2 = calculaMedia(6, 8, 9)
  let media3 = calculaMedia(4, 4, 4)
  console.log(media1)
  console.log(media2)
  console.log(media3)
})()