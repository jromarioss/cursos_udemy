using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Conversao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Conversão Implicita
            byte num1 = 100; // 8bits
            ushort num2; // 16bits

            float num3 = 1250.45F;
            double num4 = num3;

            num3 = num1;

            num2 = num1;

            int numero = 'C';
            #endregion

            #region Conversão Explícita
            // força a conversão e pode ocorrer perca de dados
            //ushort num1 = 100;
            //byte num2 = (byte)num1; // força a conversão

            //float num3 = 2500F;
            //int num4 = (int)num3;

            //char letra = (char)97;
            #endregion

            #region Parse
            // transforma string em numérico
            //string txtNumero = "1985";

            //int numero = int.Parse(txtNumero); // converte string para número

            //byte num1 = byte.Parse("120");

            //double num2 = double.Parse("130845");

            //float num3 = float.Parse("123.43");
            #endregion

            #region Classe Converte
            string texto = Convert.ToString(2500);

            double num1 = Convert.ToDouble(false);

            int num2 = Convert.ToInt32('C');
            #endregion

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
