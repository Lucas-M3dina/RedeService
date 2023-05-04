using System;
using System.Collections.Generic;
using System.IO;


namespace RedeSevice.Models
{
    public class Numeros : BaseTexto
    {

        private const string PATH = "Textos/numeros.txt";

        public Numeros()
        {
            CriarPastaEArquivo(PATH);
        }


        private string PrepararLinha(int n)
        {
            return $"{n};";
        }

        public void Criar(int n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);

        }

        public List<int> LerTodos()
        {
            List<int> numeros = new List<int>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                numeros.Add(Int32.Parse(linha[0]));
            }

            numeros = numeros.OrderBy(x => x).ToList();

            return numeros;
        }


        public void Deletar()
        {
            List<string> linhas = new();
            ReescreverTexto(PATH, linhas);
        }

    }
}
