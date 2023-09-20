const arr = [1, 2, 3];

function sun() {
  console.log(arguments);
  console.log(arguments.length);
}

sun(...arr); // { '0': 1, '1': 2, '2': 3 }