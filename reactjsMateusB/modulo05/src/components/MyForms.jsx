import { useState } from "react";

import "./Myforms.css";

export function MyForms({ user }) {
  const [name, setName] = useState(user ? user.name : '');
  const [email, setEmail] = useState(user ? user.email : '');
  const [bio, setBio] = useState("")
  const [role, setRole] = useState("");

  function handleName(e) {
    setName(e.target.value);
  }

  function handleSubmit(e) {
    e.preventDefault(); // para o envio
    console.log("enviando o formulário");
    console.log(`Nome: ${name} | email: ${email} | bio: ${bio} | posição: ${role}`)

    setEmail('');
    setName('');
    setBio('');
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="name">Nome:</label>
          <input 
            type="text" 
            name="name" 
            placeholder="Digite seu nome"
            value={name}
            onChange={handleName} />
        </div>

        <label>
          <span>E-mail:</span>
          <input 
            type="email"
            name="email" 
            placeholder="Digite seu e-mail"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </label>

        <label>
          <span>Bio:</span>
          <textarea 
            name="bio" 
            placeholder="Descrição do usuário"
            value={bio}
            onChange={(e) => setBio(e.target.value)}
          ></textarea>
        </label>

        <label>
          <span>Função do Sistema</span>
          <select name="role" onChange={(e) => setRole(e.target.value)} value={role}>
            <option value="user">Usuário</option>
            <option value="editor">Editor</option>
            <option value="admin">Adm</option>
          </select>
        </label>

        <input type="submit" value="Enviar" />
      </form>
    </div>
  )
}