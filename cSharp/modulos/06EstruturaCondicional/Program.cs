using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06EstruturaCondicional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region IF ELSE
            //string dia = "bom dia";

            //if (dia == "bom dia")
            //{
            //    Console.WriteLine("Sim é bom dia");
            //} else
            //{
            //    Console.WriteLine("Não é bom dia");
            //}
            #endregion

            #region IF ELSE, ELSE IF
            //string dia = "boa noite";

            //if (dia == "bom dia")
            //{
            //    Console.WriteLine("É de manhã.");
            //} else if (dia == "boa tarde")
            //{
            //    Console.WriteLine("Ainda não é de noite");
            //} else
            //{
            //    Console.WriteLine("É de noite");
            //}
            #endregion

            #region Condicional aninhada
            //int numero = 10;

            //if (numero < 5)
            //{
            //    Console.WriteLine("É de manhã.");

            //    if ((numero % 2) == 0)
            //    {
            //        Console.WriteLine("É par");
            //    } else
            //    {
            //        Console.WriteLine("É impa.");
            //    }
            //}
            #endregion

            #region Operadores ternário
            //int numero = 10;
            //string mensagem = "";
            //mensagem = numero > 5 ? "é maior que 5" : "é menor que 5";
            #endregion

            #region Calculo IMC
            Console.Write("Informe o peso em kg: ");
            double peso = double.Parse(Console.ReadLine());

            Console.Write("Informe a altura em metros: ");
            double altura = double.Parse(Console.ReadLine());

            double valorIMC = peso / (altura * altura);

            if (valorIMC < 20)
            {
                Console.WriteLine("\nIMC = " + valorIMC + " -> Abaixo do peso.");
            } else if ((valorIMC >= 20) && (valorIMC <= 24))
            {
                Console.WriteLine("\nIMC = " + valorIMC + " -> Normal.");
            } else if ((valorIMC >= 25) && (valorIMC <= 29))
            {
                Console.WriteLine("\nIMC = " + valorIMC + " -> Acima do peso.");
            } else if ((valorIMC >= 30) && (valorIMC <= 34))
            {
                Console.WriteLine("\nIMC = " + valorIMC + " -> Obeso.");
            } else
            {
                Console.WriteLine("\nIMC = " + valorIMC + " -> Muito obeso.");
            }

            Console.ReadKey();
            #endregion
        }
    }
}
