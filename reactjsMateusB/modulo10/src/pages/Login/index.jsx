import styles from "./styles.module.css";

export const Login = () => {
  return (
    <div className={styles.login}>
      <h1>Logar</h1>
      <p>Crie seu usuário e compartilhe suas histórias</p>
      <form action="">
        <label htmlFor="">
          <span>E-mail:</span>
          <input type="email" name="email" required placeholder="E-mail do usuário" />
        </label>
        <label htmlFor="">
          <span>Senha:</span>
          <input type="password" name="password" required placeholder="Senha do usuário" />
        </label>
        <button className="btn">Entrar</button>
      </form>
    </div>
  )
}