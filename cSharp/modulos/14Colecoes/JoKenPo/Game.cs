using System;
using System.Drawing;

namespace JoKenPo
{
    public class Game
    {
        public enum Resultado
        {
            Ganhar,
            Perder,
            Empatar
        }
        //pegar as imagens
        public static Image[] images =
        {   //para pegar as imagens pelo caminho dela
            Image.FromFile("imagens/Pedra.png"),//0
            Image.FromFile("imagens/Tesoura.png"),//1
            Image.FromFile("imagens/Papel.png"),//2
        };

        public Image ImagemPc { get; private set; }
        public Image ImagemJogador {  get; private set; }

        public Resultado Jogar(int jogador)
        {
            // jogada da máquina aleatório
            int maquina = JogadaPc();
            // imagem do jogador e da máquina
            ImagemJogador = images[jogador];
            ImagemPc = images[maquina];
            //verificação quem ganho 0 Pedra, 1 Tesoura, 2 Papel
            if (jogador == maquina)
            {
                return Resultado.Empatar;
                //           Pedra ganha tesoura                Tesoura ganha papel            Papel ganha pedra
            } else if ((jogador == 0 && maquina == 1) || (jogador == 1 && maquina == 2) || (jogador == 2 && maquina == 0))
            {
                return Resultado.Ganhar;
            } else
            {
                return Resultado.Perder;
            }
        }

        public int JogadaPc()
        {
            int numero = DateTime.Now.Millisecond;

            if (numero < 333)
            {
                return 0;
            } else if (numero >= 333 && numero < 667)
            {
                return 1;
            } else
            {
                return 2;
            }
        }
    }
}
