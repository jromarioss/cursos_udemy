let idade = 18
let paisPresente = true
let comprouBilhete = false
const podeViajar = (idade >= 18 || paisPresente) && comprouBilhete

if (comprouBilhete) {
  console.log("Sim comprou o bilhete")
  if (idade >= 18) {
    console.log("Pode viajar sozinho")
  } else {
    console.log("Pode viajar somente acompanhado com os pais")
  }
} else {
  console.log("Não comprou o bilhete")
}