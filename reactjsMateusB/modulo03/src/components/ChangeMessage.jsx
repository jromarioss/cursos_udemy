export function ChangeMessage({onChangeMessage}) {
  const messages = ['oi', 'olá', 'roudy']
  return (
    <div>
      <button onClick={() => onChangeMessage(messages[0])}>1</button>
      <button onClick={() => onChangeMessage(messages[1])}>2</button>
      <button onClick={() => onChangeMessage(messages[2])}>3</button>
    </div>
  )
}