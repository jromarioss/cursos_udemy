function fn(cb) {
  console.log('executar ação de callback')
  console.log(typeof cb)
  typeof cb === 'function' && cb()
}

function callback() {
  console.log('função passada por parâmetro')
}

fn(callback)

const objeto = {
  callback
}

objeto.callback()

function fn2(n) {
  return function(n1) {
    return n * n1
  }
}

const funcao2 = fn2(10)
const mult = funcao2(2)
console.log(mult) // 20