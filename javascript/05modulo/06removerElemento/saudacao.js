(function() {
  const nomeUsuario = null
  const elemento = document.querySelector('.top-bar p')

  if (nomeUsuario) {
    elemento.innerHTML += `<strong>${nomeUsuario}<strong>`
  } else {
    // permite escrever o css dentro do javascript
    //elemento.style.display = 'none'
    elemento.parentElement.style.display = 'none' // parentElemento é o elemento pai
    elemento.remove() // remove o elemento da página

    const elementToRemove = elemento.parentElement //pega o pai
    elementToRemove.parentElement.removeChild(elementToRemove) // apartir do pai remove o filho
  }
  
})()