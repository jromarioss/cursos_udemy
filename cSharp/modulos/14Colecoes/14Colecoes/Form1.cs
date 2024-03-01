using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14Colecoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lista.Items.Clear(); // limpa a lista do listbox

            List<string> nomes = new List<string>(); // cria um classe do tipo list
            nomes.Add("Mario"); // adiciona elemento na list nomes
            nomes.Add("João");
            nomes.Add("Maria");
            // nomes[1]; acessa o elemento do indice 1
            nomes.AddRange(new List<string> { "Pedro", "Romario" }); // adiciona mais de 1 elementos

            nomes.Remove("João"); // remove um elemento da lista e retorna um boleano
            nomes.Contains("Maria"); // vê se tem o elemento Maria e retorna um boleano
            nomes.Count(); // conta quantos elemento tem na list
            nomes.Sort(); // organiza em ordem alfabetica
            nomes.IndexOf("Mario"); // saber o indice do elemento
            nomes.Insert(6, "Tirulipa"); // adiciona um elemento no indice 6
            nomes.RemoveAt(6); // remove o elemento pelo indice
            nomes.Clear(); // limpa a lista

            foreach (string name in nomes) // percorre em uma list
            {
                lista.Items.Add(name); // adiciona na lista no form
            }
        }

        private void btnHashSet_Click(object sender, EventArgs e)
        {
            lista.Items.Clear();
            // o mesmo que list porém não aceita elemento repetidos
            HashSet<string> veiculos = new HashSet<string>()
            {
                "Celta", "Fusca", "Gol", "Uno", "Fiorino"
            };
            veiculos.Add("Palio");

            veiculos.Contains("Palio"); // verifica se contain o elemento e retorna boolean
            veiculos.Remove("Fusca"); // remove o elemento retorna boolean
            veiculos.Count(); // retorna a quantidade de elementos
            veiculos.Clear(); // limpa a hasset
            veiculos.ElementAt(5); // pega o elemento do indice 5
            veiculos.First(); // retorna o primeiro elemento
            veiculos.Last(); // retorna o último elemento

            foreach (string item in veiculos)
            {
                lista.Items.Add(item);
            }
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> alunos = new Dictionary<int, string>()
            { // pode repetir elementos porém a chave não
                { 03, "Dani" }, { 10, "Carlos"}, { 07, "Luiz" }
            };

            alunos.Add(02, "Pedro"); // adiciona chave e valor
            alunos.Count(); // retorna a quantidade de elementos
            alunos.Remove(10); // remove o elemento pela chave retorna boolean
            alunos.Clear(); // limpa o dictionary
            alunos.First(); // retorna o primeiro elemento
            alunos.Last(); // retorna o último elemento
            alunos.ContainsKey(1); // verifica se contain a chave e retorna boolean
            alunos.ContainsValue("Carlos"); // verifica se contain o valor e retorna boolean
            alunos.ElementAt(5); // pega o elemento do indice 5

            foreach (KeyValuePair<int, string> item in alunos) // para percorrer um dictionary
            {
                lista.Items.Add($"{item.Key}. {item.Value}");
            }
        }

        private void btnSorted_Click(object sender, EventArgs e)
        {
            SortedList<int, string> alunos = new SortedList<int, string>()
            {
                {27, "Dani"}, {23, "Julio"}, {8, "Luiz"}, {11, "Pedro"},
            };

            alunos.Add(2, "Macarrão"); // adiciona chave e valor
            alunos.Count(); // retorna a quantidade de elementos
            alunos.Remove(10); // remove o elemento pela chave retorna boolean
            alunos.Clear(); // limpa o dictionary
            alunos.First(); // retorna o primeiro elemento
            alunos.Last(); // retorna o último elemento
            alunos.ContainsKey(1); // verifica se contain a chave e retorna boolean
            alunos.ContainsValue("Carlos"); // verifica se contain o valor e retorna boolean
            alunos.ElementAt(5); // pega o elemento do indice 5

            foreach (KeyValuePair<int, string> item in alunos) // se colocar o .Reverse() mostra inverso
            {
                lista.Items.Add($"{item.Key}. {item.Value}");
            }
        }

        private void btnSortedDictionary_Click(object sender, EventArgs e)
        {
            SortedDictionary<int, string> alunos = new SortedDictionary<int, string>()
            {
                {27, "Dani"}, {23, "Julio"}, {8, "Luiz"}, {11, "Pedro"},
            };

            alunos.Add(2, "Macarrão"); // adiciona chave e valor
            alunos.Count(); // retorna a quantidade de elementos
            alunos.Remove(10); // remove o elemento pela chave retorna boolean
            alunos.Clear(); // limpa o dictionary
            alunos.First(); // retorna o primeiro elemento
            alunos.Last(); // retorna o último elemento
            alunos.ContainsKey(1); // verifica se contain a chave e retorna boolean
            alunos.ContainsValue("Carlos"); // verifica se contain o valor e retorna boolean
            alunos.ElementAt(5); // pega o elemento do indice 5

            foreach (KeyValuePair<int, string> item in alunos) // se colocar o .Reverse() mostra inverso
            {
                lista.Items.Add($"{item.Key}. {item.Value}");
            }
        }

        private void btnSortedSet_Click(object sender, EventArgs e)
        {
            SortedSet<string> nomes = new SortedSet<string>()
            {
                "Dani", "Julio", "Luiz", "Pedro"
            };

            nomes.Add("Macarrão"); // adiciona o valor
            nomes.Reverse(); // inverte a ordem
            nomes.Count(); // retorna a quantidade de elementos
            nomes.Remove("Luiz"); // remove o elemento retorna boolean
            nomes.Clear(); // limpa o dictionary
            nomes.First(); // retorna o primeiro elemento
            nomes.Last(); // retorna o último elemento
            nomes.Contains("Pedro"); // verifica se contain o elemento e retorna boolean
            nomes.ElementAt(5); // pega o elemento do indice 5

            foreach (string item in nomes) // se colocar o .Reverse() mostra inverso
            {
                lista.Items.Add(item);
            }
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            Queue<string> fila = new Queue<string>();
            fila.Enqueue("Pedro"); // adiciona um elemento na fila
            fila.Enqueue("Marcos"); // adiciona um elemento na fila
            fila.Enqueue("Julia"); // adiciona um elemento na fila
            fila.Enqueue("Amarildo"); // adiciona um elemento na fila

            fila.Count(); // quantos elementos tem na fila
            fila.Peek(); // pega o elemento do inicio da fila sem remover
            fila.Dequeue(); // remove o primeiro elemento da fila e retorna
            fila.First(); // retorna o primeiro elemento da fila e não remove
            fila.Last(); // retorna o último elemento da fila e não remove
            fila.Clear(); // limpa a lista

            // enquanto tiver elemento exiba o elemento e a quantidade
            while (fila.Count > 0)
            {
                fila.Dequeue();
                fila.Count();

                foreach (string item in fila)
                {
                    lista.Items.Add(item);
                }
            }
        }

        private void btnStack_Click(object sender, EventArgs e)
        {
            Stack<string> pilha = new Stack<string>();
            pilha.Push("Pedro"); // adiciona um elemento no topo da pilha
            pilha.Push("Marcos"); // adiciona um elemento no topo da pilha
            pilha.Push("Julia"); // adiciona um elemento no topo da pilha
            pilha.Push("Amarildo"); // adiciona um elemento no topo da pilha

            pilha.Count(); // quantos elementos tem na fila
            pilha.Peek(); // retorna o elemento do top da pilha e não remove
            pilha.Pop(); // retorna o elemento do top da pilha e remove
            pilha.First(); // retorna o primeiro elemento da fila e não remove
            pilha.Last(); // retorna o último elemento da fila e não remove
            pilha.Clear(); // limpa a lista

            foreach (string item in pilha)
            {
                lista.Items.Add(item);
            }
        }
    }
}
