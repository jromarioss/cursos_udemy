using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Vetores
            //string[] nomes =
            //{
            //    "Maria", "Pedro", "Miguel"
            //};

            //Console.WriteLine(nomes[2]); // Miguel
            //Console.ReadKey();
            #endregion

            #region Vetores bidimensionais
            int[,] numeros = new int[2, 3]; // 2 linhas e 3 colunas
            numeros[0, 0] = 10;
            numeros[0, 1] = 30;
            numeros[0, 2] = 45; // [ 10, 30, 45 ]
            numeros[1, 0] = 43; // [ 43, 03, 78 ]
            numeros[1, 1] = 33;
            numeros[1, 2] = 78;

            Console.Write("[" + numeros[0, 0] + "]"); // 10
            Console.Write("[" + numeros[0, 1] + "]"); // 30
            Console.Write("[" + numeros[0, 2] + "]"); // 45
            Console.WriteLine("");
            Console.Write("[" + numeros[1, 0] + "]"); // 43
            Console.Write("[" + numeros[1, 1] + "]"); // 33
            Console.Write("[" + numeros[1, 2] + "]"); // 78
            Console.WriteLine("");

            string[,] nomes =
            {
                {"Pedro", "Julia", "Miguel"},
                {"Giovana", "José", "Olavo"}
            };

            Console.Write("[" + nomes[0, 0] + "]");
            Console.Write("[" + nomes[0, 1] + "]");
            Console.Write("[" + nomes[0, 2] + "]");
            Console.WriteLine();
            Console.Write("[" + nomes[1, 0] + "]");
            Console.Write("[" + nomes[1, 1] + "]");
            Console.Write("[" + nomes[1, 2] + "]");
            Console.ReadKey();
            #endregion
        }
    }
}
