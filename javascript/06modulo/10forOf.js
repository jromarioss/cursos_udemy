const arr = [1, 2, 3];
const obj = {
  nome: 'maria', idade: 20, email: 'maria@email.com'
}

// o for in percorre obj
for (let props in obj) {
  console.log(props); // nome idade email acessa as props
  console.log(obj[props]); // maria 20 mari@.. acessa os valores
}

// for of intera sobre array
for (n of arr) {
  console.log(n); // acessa os valores do array
}