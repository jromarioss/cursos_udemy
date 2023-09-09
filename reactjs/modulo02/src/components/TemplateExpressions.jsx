const TemplateExpressions = () => {
  const name = 'Romario'
  const data = {
    age: 29,
    job: 'Programmer'
  }

  return (
    <div>
      <h1>Olá {name}, tudo bem?</h1>
      <p>você atua como: {data.job}</p>
    </div>
  )
}

export default TemplateExpressions
