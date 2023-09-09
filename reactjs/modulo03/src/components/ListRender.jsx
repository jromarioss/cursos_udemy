import { useState } from "react"

const ListRender = () => {
  const [list, setList] = useState([
    {id: 1, name: 'Maria', age: 12}, 
    {id: 2, name: 'Pedro', age: 22}, 
    {id: 3, name: 'Julia', age: 32}, 
    {id: 4, name: 'Carlos', age: 52},
    {id: 5, name: 'Juliano', age: 62},
  ])

  const deleteName = () => {
    const randomNumber = Math.floor(Math.random() * 6)

    setList((prev) => {
      return prev.filter((user) => randomNumber !== user.id)
    })
  }

  return (
    <div>
      <ul>
        {list.map((item) => (
          <li key={item.id}>{item.name} - {item.age}</li>
        ))}
      </ul>
      <button onClick={deleteName}>deletar</button>
    </div>
  )
}

export default ListRender