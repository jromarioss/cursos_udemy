(function() {
  const nomeUsuario = 'Pedro'
  
  if (nomeUsuario)   {
    const topBarElemento = document.createElement('div') // cria elemento div
    topBarElemento.className = 'top-bar' // a div recebe a classe top-bar
    topBarElemento.innerHTML = `<p>Olá, ${nomeUsuario}</p>` // insira um html dentro do elemento div

    // inserir o elemento div em algum lugar
    const elementoPai = document.querySelector('.hero') // o elemento pai

    elementoPai.insertBefore(topBarElemento, elementoPai.firstElementChild) // 1 novo elemento, 2 a referencia
  }
})()