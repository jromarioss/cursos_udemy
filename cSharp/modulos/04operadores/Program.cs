using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04operadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Operadores aritméticos
            //int num1 = 10;
            //int num2 = 2;

            //Console.WriteLine(num1 + num2); // 12
            //Console.WriteLine(num1 - num2); // 8
            //Console.WriteLine(num1 * num2); // 20
            //Console.WriteLine(num1 / num2); // 5
            //Console.WriteLine(num1 % num2); // 0
            #endregion

            #region Presedência
            //int num1 = 10;
            //int num2 = 2;
            //int num3 = 5;

            //// faz primeiro o () depois o *
            //int res = (num1 + num2) * num3;

            //Console.WriteLine(num1 + num2); // 12
            //Console.WriteLine(num1 - num2); // 8
            //Console.WriteLine(num1 * num2); // 20
            //Console.WriteLine(num1 / num2); // 5
            //Console.WriteLine(num1 % num2); // 0
            #endregion

            #region Incremento e decremento
            //int num1 = 10;

            //int res = num1++; // incrementa 1 no 10 = 10 + 1 = 11
            //int res2 = num1--; // decrementa 1 no 10 = 10 - 1 = 09

            //int res3 = ++num1; // mostra 10 depois incrementa 1
            //int res4 = --num1; // mostra 09 depois decrementa 09
            #endregion

            #region Concatenação
            //string nome = "Maria ";
            //string sobrenome = "Santos";

            //Console.WriteLine(10 + 5); //15
            //Console.WriteLine(nome + sobrenome); // concatena quando é string
            #endregion

            #region Operadores de atribuição
            //int num1 = 10; //atribui 10 no num1
            //num1 += 10; // seu valor que é 10 mais 10 = 20
            //num1 -= 10; // seu valor que é 10 menos 10 = 0
            #endregion

            #region Operadores de igualdade
            //bool res = 100 == 50; // se 100 é igual a 500 retorna true ou false
            //bool res2 = 200 != 10; // se é diferente
            //bool res3 = "João" == "Maria";
            #endregion

            #region Operadores relacionais
            //bool res = 100 < 5; // retorna true ou false
            //bool res2 = 100 <= 5; // retorna true ou false
            //bool res3 = 100 > 5; // retorna true ou false
            //bool res4 = 100 >= 5; // retorna true ou false
            #endregion

            #region Operadores lógico
            //bool res = 100 > 50; // true
            //bool res2 = 50 == 50; // true
            //bool res3 = 50 != 50; // false

            //bool res4 = res && res2; // true and true = true
            //bool res5 = res && res3; // true and false = false
            //bool res6 = res || res2; // true or true = true
            //bool res7 = res || res3; // true or false = true
            #endregion

            #region Convertor de temperatura
            double c, f, k;

            Console.WriteLine("Conversor de temperatura");
            Console.Write("Insira a temperatura em Celcius:");
            c = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");

            f = (c * 9 / 5) + 32;
            k = c + 273.15;

            Console.WriteLine($"{c} graus celcius = {f} graus fahrenheit");
            Console.WriteLine($"{c} graus celcius = {k} graus kelvin");
            Console.WriteLine("---------------------------------");
            Console.ReadKey();
            #endregion
        }
    }
}
