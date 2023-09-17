import { useState } from 'react'
import Naruto from './assets/naruto02.jpg'
import { CarDetails } from './components/CarDetails'
import ConditionalRender from './components/ConditionalRender'
import { Container } from './components/Container'
import { ExecuteFunction } from './components/ExecuteFunction'
import { Fragment } from './components/Fragment'
import ListRender from './components/ListRender'
import ManageData from './components/ManageData'
import ShowUserName from './components/ShowUserName'
import { Mensagem } from './components/Message'
import { ChangeMessage } from './components/ChangeMessage'

function App() {
  const cars = [
    { id: 1, brand: 'bmw', km: 1000, color: 'red', newCar: false },
    { id: 2, brand: 'Uno', km: 0, color: 'white', newCar: true },
    { id: 3, brand: 'Gol Bola', km: 100230, color: 'black', newCar: false },
    { id: 4, brand: 'Ferra', km: 10000, color: 'red', newCar: false },
  ]

  const [message, setMessage] = useState('')

  function handleMessage(msg) {
    setMessage(msg)
  }

  function showMessage() {
    console.log('Evento do componente pai')
  }

  return (
    <>
      <h1>Avançando em React</h1>
      <div>
        {/* Imagem em public acessa pela / */}
        <img src="/naruto01.jpg" alt="naruto" width={200} />
      </div>
      <div>
        {/* Imagem com src */}
        <img src={Naruto} alt="naruto" />
      </div>
      <ManageData />
      <ListRender />
      <ConditionalRender />
      <ShowUserName nameUser="Romário" />

      {cars.map((car) => (
        <CarDetails key={car.id} brand={car.brand} km={car.km} color={car.color} newCar={car.newCar} />
      ))}

      <Fragment />

      <Container myValue='testee'>
        <p>Este é o conteúdo</p>
      </Container>

      <ExecuteFunction onMyFunction={showMessage} />

      <Mensagem msg={message} />
      <ChangeMessage onChangeMessage={handleMessage} />
    </>
  )
}

export default App
