function sun() {
  const numbers = Array.from(arguments); // [1, 2, 3]
  const numbers2 = [...arguments]; // [1, 2, 3]
}

function avarege() {
  sun(...arguments) / arguments.length
}

sun(1, 2, 3)

let media = avarege(1, 2, 3, 4, 5)