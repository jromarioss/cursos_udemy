let arr = [1, 3, 4, 7, 9];

arr.push(12); // acrescenta valor no final do array, e retorna o índice e modifica a arr original
arr.pop(); // remove o último elemento e retorna esse elemento e modifica a arr original
arr.shift(); // remove o primeiro elemento e retorna esse elemento e modifica a arr original
arr.unshift(3, 12, 55); // adiciona elemento no inicio do array e retorna o índice e modifica a arr original

let arr2 = [0, 1, 2, 3, 4, 5, 6, 7, 8];

let newArr2 = arr2.slice(2, 5); // recorta um pedaço do array 1pr o inicio, 2pr até não altera a array original
let newArr4 = arr2.splice(1, 3, "Olá mundo"); // modifica a array original, 1pr o inicio, 2pr remove 3 elementos,  3pr adiciona novo elemento, e retorna os valore removido

console.log(arr2);
console.log(newArr2);