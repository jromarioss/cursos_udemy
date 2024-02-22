using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03conversaoTiposDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Conversão implicita
            //byte num1 = 100;
            //ushort num2;
            //num2 = num1; //conversão implicita, permite receber valores de outra variável

            //float num3 = 1250.45f;
            //double num5 = num3; //conversão implicita, permite receber valores de outra variável

            //char letra = 'C';
            //int numero = letra;
            #endregion

            #region Conversão explicita
            //ushort num1 = 100;
            //byte num2 = (byte)num1; //força ele converter para o tipo byte

            //float num3 = 2500.32f;
            //int num4 = (int)num3;

            //char letra = (char)82;
            #endregion

            #region Método Parse
            //string txtNumero = "1985";
            //int numero = int.Parse(txtNumero); // converte para int o parse

            //byte num1 = byte.Parse("120");
            //double num2 = double.Parse("123.32");
            #endregion

            #region Método Convert
            string texto = Convert.ToString(29010290); // converte para string
            double num1 = Convert.ToDouble(false); // retorna 0 por que 0 é falso
            int nume = Convert.ToInt32('C');
            #endregion
        }
    }
}
