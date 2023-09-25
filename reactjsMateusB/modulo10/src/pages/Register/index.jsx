import { useState, useEffect } from "react";

import styles from "./styles.module.css";

export const Register = () => {
  return (
    <div className={styles.register}>
      <h1>Cadastre-se para</h1>
      <p>Crie seu usuário e compartilhe suas histórias</p>
      <form action="">
        <label htmlFor="">
          <span>Nome:</span>
          <input type="text" name="displayName" required placeholder="Nome do usuário" />
        </label>
        <label htmlFor="">
          <span>E-mail:</span>
          <input type="email" name="email" required placeholder="E-mail do usuário" />
        </label>
        <label htmlFor="">
          <span>Senha:</span>
          <input type="password" name="password" required placeholder="Senha do usuário" />
        </label>
        <label htmlFor="">
          <span>Confirmação de senha:</span>
          <input type="password" name="password" required placeholder="Confirme a senha" />
        </label>
        <button className="btn">Cadastrar</button>
      </form>
    </div>
  )
}