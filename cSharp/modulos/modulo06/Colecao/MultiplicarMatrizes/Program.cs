using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicarMatrizes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz1 = new int[2, 3];
            int[,] matriz2 = new int[3, 2];
            int[,] resultado = new int[2, 2];

            Console.WriteLine("Preencher a matriz # 1");

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("#1. Posição [" + i + "][" + j + "]: ");
                    matriz1[i ,j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nPreencher a matriz # 1");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("#1. Posição [" + i + "][" + j + "]: ");
                    matriz2[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nResultado da matriz # 1 X matriz # 2");
            resultado[0, 0] = (matriz1[0, 0] * matriz2[0, 0]) + (matriz1[0,1] * matriz2[1,0]) + (matriz1[0, 2] * matriz2[2, 0]);
            resultado[1, 0] = (matriz1[1, 0] * matriz2[0, 0]) + (matriz1[1,1] * matriz2[1,0]) + (matriz1[1, 2] * matriz2[2, 0]);
            resultado[0, 1] = (matriz1[0, 0] * matriz2[0, 1]) + (matriz1[0,1] * matriz2[1,1]) + (matriz1[0, 2] * matriz2[2, 1]);
            resultado[1, 1] = (matriz1[1, 0] * matriz2[0, 1]) + (matriz1[1,1] * matriz2[1,1]) + (matriz1[1, 2] * matriz2[2, 1]);

            Console.WriteLine("[" + resultado[0, 0] + "][" + resultado[0,1] + "]");
            Console.WriteLine("[" + resultado[1, 0] + "][" + resultado[1,1] + "]");
            Console.ReadKey();
        }
    }
}
