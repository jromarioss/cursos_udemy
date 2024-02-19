using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01VariaveisConstantesTipoDados
{
    internal class Program
    {
        enum Notas
        {
            Minimo,
            Media,
            Maximo
        }

        struct Pessoa
        {
            public string nome;
            public int idade;
            public double altura;
        }

        static void Main(string[] args)
        {
            #region Inteiros
            //sbyte num1 = 10; // 8 bits, de -128 a 127
            //short num2 = 20; // 16 bits, –32.768 a 32.767
            //int num3 = 30; // 32 bits, –2.147.483.648 a 2.147.483.647
            //long num4 = 40L; // 64 bits, –9.223.372.036.854.775.808 a 9.223.372.036.854.775.807

            //// Integral sem sinal
            //byte num5 = 10; // 8 bits, intervalo de 0 a 255
            //ushort num6 = 20; // 16 bits, de 0 a 65.535
            //uint num7 = 30;  // 32 bits, de 0 a 4.294.967.295
            //ulong num8 = 40L; // 64 bits, de 0 a 18.446.744.073.709.551.615

            //sbyte numero;
            //numero = 100;

            //numero = 120;
            //numero = num1;
            #endregion

            #region Reais
            //float real1 = 100.75f; // 32 bits, de 1,5 × 10-45 a 3,4 × 1038, precisão de 7 dígitos => Sufixo f, Ex.: 10.5f
            //double real2 = 12500.45; // 64 bits, de 5,0 × 10-324 a 1,7 × 10308, precisão de 15 dígitos => Sufixo d (opcional), Ex.: 10.5d
            //decimal real3 = 752538.457m; // 128 bits, intervalo de pelos menos –7,9 × 10-28 a 7,9 × 1028, com precisão de pelo menos 28 dígitos => Sufixo m, Ex.: 10.5m

            //double valor;
            //valor = real1;
            #endregion

            #region Caracteres
            //char letra = '\u0041'; //é o código do caracteres
            //char escape = '\n'; //aplica o escape é a \ assim dá a quebra de linha e para exibir o \ coloque o \\
            //char literal = 'C';
            #endregion

            #region Boolean
            //bool verificar = false;
            //verificar = true;
            #endregion

            #region String
            //string texto = @"Gabriel Artigas\n 1985 @@??$$"; //o @ permite o escape para usar o \n
            //string mensagem = null;
            //mensagem = texto;
            #endregion

            #region Var
            //var valor = 140; //aceita qualquer tipo, porém esse valor fica até o final
            #endregion

            #region Objeto
            //object obj = false;
            //obj = 200;
            //obj = "Gabriel";
            #endregion

            #region Constantes
            //const double pi = 3.1415;
            //const string nome = "Gabriel";
            #endregion

            #region Enumeração
            //Notas notasAlunos = Notas.Media;
            #endregion

            #region Estruturas
            Pessoa p1 = new Pessoa();
            p1.altura = 1.65;
            p1.idade = 35;
            p1.nome = "Gabriel";

            Pessoa p2 = new Pessoa()
            {
                nome = "Arthur",
                idade = 9,
                altura = 1.35
            };

            p1.nome = "Logan";
            #endregion

            Console.WriteLine(p1.nome + " tem a idade " + p1.idade + " e a altura " + p1.altura); //exibe o valor
            Console.ReadKey(); //para o console no valor de cima
        }
    }
}
