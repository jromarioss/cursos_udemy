using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02EntradaESaidaDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Olá"); //saída de dados no terminal e quebra a linha
            //Console.Write("Olá"); //saída de dados no terminal não quebra a linha

            //int codigo = Console.Read(); //captura o caracteres que o usuário digitou e armazena em código
            //string texto = Console.ReadLine(); //pega um texto digitado pelo usuário
            //Console.WriteLine(texto);
            //Console.ReadKey(); //realiza a pausa no console

            #region Exercício inverter nome
            string nome1, nome2, nome3, nome4, auxiliar;

            Console.WriteLine("Digite o nome #1: ");
            nome1 = Console.ReadLine();

            Console.WriteLine("Digite o nome #2: ");
            nome2 = Console.ReadLine();

            Console.WriteLine("Digite o nome #3: ");
            nome3 = Console.ReadLine();

            Console.WriteLine("Digite o nome #4: ");
            nome4 = Console.ReadLine();

            auxiliar = nome1;
            nome1 = nome4;
            nome4 = auxiliar;
            auxiliar = nome2;
            nome2 = nome3;
            nome3 = auxiliar;

            Console.WriteLine();
            Console.WriteLine("Nomes inserido na sequência invertida");
            Console.WriteLine(nome1);
            Console.WriteLine(nome2);
            Console.WriteLine(nome3);
            Console.WriteLine(nome4);
            #endregion
        }
    }
}
