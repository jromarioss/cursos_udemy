function sum() {
  const number = [];
  // for (let i = 0; i < arguments.length; i++) {
  //   number.push(arguments[i]);
  // }
  // console.log(number);

  Array.prototype.forEach.call(arguments, (arg, i) => {
    number.push(arg);
  }) // pega emprestada o método foreach

  console.log(number)
}

sum(1, 2, 3);
//sum.call(null, 1, 2, 3, 4, 5);
//sum.apply(null, [1, 2, 3, 4]); // passa um array no apply