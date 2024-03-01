using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoKenPo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPedra_Click(object sender, EventArgs e)
        {
            StartGame(0);
        }

        private void btnPapel_Click(object sender, EventArgs e)
        {
            StartGame(2);
        }

        private void btnTesoura_Click(object sender, EventArgs e)
        {
            StartGame(1);
        }

        private void StartGame(int opcao)
        {
            labelResultado.Visible = false; // fica invisível
            Game jogo = new Game();
            //pega a imagem caso ele ganha, perda ou empata
            switch (jogo.Jogar(opcao))
            {
                case Game.Resultado.Ganhar:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Ganhar.png");
                    goto default;// manda para o default
                case Game.Resultado.Perder:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Perder.png");
                    goto default;// manda para o default
                case Game.Resultado.Empatar:
                    pictureResultado.BackgroundImage = Image.FromFile("imagens/Empatar.png");
                    goto default;// manda para o default
                default:
                    pictureJogador.Image = jogo.ImagemJogador;
                    pictureMaquina.Image = jogo.ImagemPc;
                    break;
            }
        }
    }
}
