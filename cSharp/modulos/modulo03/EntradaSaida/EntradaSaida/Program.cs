using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntradaSaida
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Romário"); // quebra a linha
            Console.Write("Santos"); // não quebra a linha

            int codigo = Console.Read(); // pega o caractere e espera o enter
            Console.WriteLine(codigo); // mostra o código do caractere digitado

            string texto = Console.ReadLine(); // pega um grupo de caracteres
            Console.WriteLine(texto); // e mostra o valor digitado

            Console.ReadKey(); // espera que digite um tecla
        }
    }
}