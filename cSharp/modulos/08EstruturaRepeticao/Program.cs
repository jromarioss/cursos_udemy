using System;

namespace _08EstruturaRepeticao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region While
            //int numero = 0;
            //while(numero <= 10) //executa ate for menor ou igual a 10
            //{
            //    Console.WriteLine($"O número é {numero}");
            //    numero++;
            //}
            //Console.ReadKey();
            #endregion

            #region Do while
            //int numero = 0;
            //do
            //{
            //    Console.WriteLine($"O número é {numero}");
            //    numero++;
            //} while (numero <= 0); //executa pelo menos uma vez
            //Console.ReadKey();
            #endregion

            #region For
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"O número é {i}");
            //    i++;
            //}
            //Console.ReadKey();
            #endregion

            #region Foreach
            //string[] nomes = { "pedro", "maria", "julia", "miguel" };

            //foreach(string nome in nomes) //percorre um array
            //{
            //    Console.WriteLine(nome);
            //}
            //Console.ReadKey();
            #endregion

            #region Fibonacci
            int a = 0;
            int b = 1;
            int c = 0;

            Console.Write("Quantos valores: ");
            int valores = int.Parse(Console.ReadLine());

            Console.Write($"Sequência de Fibonacci com {valores} valores ");

            for (int i = 0; i < valores; i++)
            {
                if (i < valores - 1)
                {
                    Console.Write($"{a}, ");

                } else
                {
                    Console.Write(a);
                }

                c = a + b;
                a = b;
                b = c;
            }
            Console.ReadKey();
            #endregion
        }
    }
}
