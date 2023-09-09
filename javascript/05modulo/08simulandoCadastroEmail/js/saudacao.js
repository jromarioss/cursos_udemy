const txtEmail = document.getElementById('txtEmail')
const msgFeed = document.getElementById('newsletterFeedback')

function cadastrarEmail() {
  const email = txtEmail.value
  msgFeed.innerHTML = `O ${email} cadastrado com sucesso`
}