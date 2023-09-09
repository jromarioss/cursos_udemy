const teste = function(cb) {
  console.log('função teste')
  
  if (typeof cb === 'function') {
    cb('passado por parâmetro para cb') // executa a callback
  }
}

const fn = function(param) {
  console.log('função anonima de callback')
  console.log(param)
}

//fn(30)

teste(fn)