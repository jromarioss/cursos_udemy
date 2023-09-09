const txtNome = document.querySelector('#txtName')
const txtEmail = document.querySelector('#txtEmail')
const labelContrato = document.querySelector('label[for="contrato"]')

txtNome.value = 'Romário' // seta o valor para
txtNome.disabled = true // desabilita o input

txtEmail.readOnly = true

console.log(txtNome.value) // Romário
console.log(labelContrato.htmlFor) // contrato
console.log(txtNome.maxLength) // 30
console.log(txtEmail.className) // input input-email