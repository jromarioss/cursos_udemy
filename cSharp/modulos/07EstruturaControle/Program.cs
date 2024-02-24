using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07EstruturaControle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Switch case
            //int escolha = 0;

            //switch (escolha)
            //{
            //    case 0:
            //        Console.WriteLine("Escolheu o 0");
            //        break;
            //    case 1:
            //        Console.WriteLine("Escolheu o 1");
            //        break;
            //    case 2:
            //        Console.WriteLine("Escolheu o 2");
            //        break;
            //    default:
            //        Console.WriteLine("Opção inválido");
            //        break;
            //}
            #endregion

            #region Declaração GOTO
            //Inicio:
            //Console.WriteLine("Escolha uma opção: ");
            //int op = int.Parse(Console.ReadLine());
            //int valor = 0;

            //switch (op)
            //{
            //    case 1:
            //        valor += 100;
            //        break;
            //    case 2:
            //        valor += 50;
            //        goto case 1; // manda lá pro case 1 de novo
            //    default:
            //        goto Inicio; // manda lá pro inicio fora do switch
            //}

            //Console.WriteLine($"Valor final: {valor}");
        #endregion

        #region Exercício calculadora
        Inicio:
            Console.Clear();

            Console.Write("Digite o primeiro número: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Escolha a operação (+ - x /): ");
            char op = char.Parse(Console.ReadLine());

            double resultado = 0;

            switch (op)
            {
                default:
                    Console.WriteLine("Erro, opção inválida");
                    break;
                case '+':
                    resultado = num1 + num2;
                    Console.WriteLine("O resultado da soma é: " + resultado);
                    break;

                case '-':
                    resultado = num1 - num2;
                    Console.WriteLine("O resultado da subtração é: " + resultado);
                    break;
                case 'x':
                case 'X':
                    resultado = num1 * num2;
                    Console.WriteLine("O resultado da multiplicação é: " + resultado);
                    break;
                case '/':
                case ':':

                    if (num2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por 0.");
                    }
                    else
                    {
                        resultado = num1 / num2;
                        Console.WriteLine("O resultado da divisão é: " + resultado);
                    }
                    break;
            }

            Console.Write("Continuar calculando (s / n)? ");
            string opcao = Console.ReadLine();

            if (opcao == "s" || opcao == "S")
            {
                goto Inicio;
            }
        }
        #endregion
    }
}
