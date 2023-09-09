let n1 = 10
let n2 = "2.5"
n2 = parseInt(n2) // converte a string para int 2
// se tem 12a ele tira o a en diante e se for a12 ñ consegue converter e fica NaN

n2 = parseFloat(n2) // converte a string para float 2.5

console.log(n1 * n2) // 20
console.log(n1 + n2) // 102 ele concatena com o mais

// tipos de conversão parseFloat, parseInt, Number()
