const Events = () => {
  const active = true;

  const handleMyEvent = (e) => { // o e relacionado ao evento
    console.log(e)
  }

  const renderSomething = (x) => {
    if (x) {
      return <h1>Renderizando isso</h1>
    } else {
      return <h1>Ou isso</h1>
    }
  }

  return (
    <div>
      <div>
        <button onClick={handleMyEvent}>clique aqui</button>
      </div>
      <div>
        <button onClick={() => console.log('Clicou!')}>Clique aqui também</button>
        <button onClick={() => {
          if (active) {
            console.log('isso não deveria está aqui')
          }
        }}>aqui também</button>
      </div>

      {renderSomething(true)}
    </div>
  )
}

export default Events