using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Variaveis
{
    internal class Program
    {
        enum Notas
        {
            Minimo = 10,
            Media = 20,
            Maxima = 30,
        }

        struct Pessoa
        {
            public string nome;
            public int idade;
            public double altura;
        }

        static void Main(string[] args)
        {
            #region Numericas Integras
            //Integral assinado suporta números negativos
            //sbyte num1 = 10; //8 bits, -128 a 127
            //short num2 = 20; //16 bits, -32.768 a 32.767
            //int num3 = 30; //32 bits, -2.147.483.648 a 2.147.482.647
            //long num4 = 40L; //64 bits -9.233.372.036.854.775.808 a 9.223.372.036.854.7755.807

            //Integral sem sinal não suporta número negativos
            //byte num5 = 10; //8 bits, 0  a 255
            //ushort num6 = 20; //16 bits, 0 a 65.535
            //uint num7 = 30; //32 bits, 0 a 4.294.967.295
            //ulong num8 = 40L; //64 bits, 0 a 18.446.744.073.709.551.615

            //sbyte numero; //cria a variável
            //numero = 100; //depois atribui o valor
            //numero = num1;
            #endregion

            #region Números Reais
            //float real1 = 100.75F; //32 bits
            //double real2 = 500.74; //64 bits
            //decimal real3 = 752538.457M; //128 bits

            //double valor;
            //valor = real2;
            #endregion

            #region Caracteres
            //char letra = '\u0045'; //usar entre aspa simples \u0056 coloca o código do caractere
            //char escape = '\n'; // o \\ da o escape
            //char literal = 'c';
            #endregion

            #region Boolean
            //bool verificar = false;
            //verificar = true;
            #endregion

            #region Strings
            //string texto = "José Romário"; // o @ antes dos aspas ignora o \n
            //string mensagem = null; //iniciada como nulo, o valor padrão quando não atribuie valor
            //mensagem = texto;
            #endregion

            #region Var
            //var valor = 140; //pode assumir qualquer valor, porém esse valor não pode mudar o tipo
            //valor = 230;
            #endregion

            #region Object
            //object obj = 100; //comporta todos os tipos e pode ser trocada a qualqer momento
            //obj = "Romário";
            #endregion

            #region Constantes
            //const double pi = 3.1415; //valor não pode ser alterado
            #endregion

            #region Enum
            //Notas notasAluno = Notas.Media;
            #endregion

            #region Struct
            Pessoa p1 = new Pessoa(); // inicializa a estrutura

            p1.nome = "Romário";
            p1.idade = 28;
            p1.altura = 1.73;

            Pessoa p2 = new Pessoa() // inicializando com os valores
            {
                nome = "Giovana",
                idade = 24,
                altura = 1.72
            };
            #endregion

            Console.WriteLine(p1.nome);
            Console.WriteLine(p1.idade);
            Console.WriteLine(p1.altura);
            Console.ReadKey(); //de uma pause e espera aperta um tecla
        }
    }
}
