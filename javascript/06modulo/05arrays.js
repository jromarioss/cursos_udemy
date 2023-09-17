let arr = [1, 4, 5, 8];

console.log(arr.reverse()); // inverte a ordem do array e altera a array original

// o reduce faz um interação em cada elemento do array e retorna um único valor
let soma = arr.reduce((acumulador, valorAtual, indice, arrayOriginal) => {
  return acumulador + valorAtual;
})

let nomes = ["Maria", "Pedro", "Luiz", "Souza", "Marcos"];

let nomeOrder = nomes.reduce((acc, atual) => {
  let primeiraLetra = atual[0];

  if (acc[primeiraLetra]) {
    acc[primeiraLetra]++;
  } else {
    acc[primeiraLetra] = 1;
  }

  return acc; // { M: 2, P: 1, L: 1, S: 1 }
}, {}) // valor de retorno

console.log(nomeOrder);