using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Condicionais
            //int valor = 32;
            //if (valor < 5)
            //{
            //    Console.WriteLine("Condição verdadeira");
            //}
            //else if (valor >= 5 && valor < 10)
            //{
            //    Console.WriteLine("Condição alternativa 1");
            //}
            //else if (valor >= 10 && valor < 20)
            //{
            //    Console.WriteLine("Condição alternativa 2");
            //}
            //else
            //{
            //    Console.WriteLine("Nenhuma das condições atendida");
            //}
            #endregion

            #region Condicional aninhada
            //int numero = 7;

            //if (numero > 5)
            //{
            //    Console.Write("O número é maior que 5");

            //    if (numero % 2 == 0)
            //    {
            //        Console.WriteLine(", e também o número par");
            //    }
            //    else
            //    {
            //        Console.WriteLine(", e também o número e impar");
            //    }
            //}
            #endregion

            #region Opeador ternario
            int numero = 10;
            string messagem = "";

            messagem = numero > 5 ? "Maior que 5" : "Menor que 5";

            Console.WriteLine(messagem);
            #endregion

            Console.ReadKey();
        }
    }
}
