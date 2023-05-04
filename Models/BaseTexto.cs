using System.Collections.Generic;
using System.IO;

namespace RedeSevice.Models
{
    public class BaseTexto
    {
        public void CriarPastaEArquivo(string _PATH)
        {
            string pasta = _PATH.Split("/")[0];
            string arquivo = _PATH.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_PATH))
            {
                File.Create(_PATH).Close();
            }
        }

        public void CriarArquivo(string _PATH)
        {
            string arquivo = _PATH;

            if (!File.Exists(_PATH))
            {
                File.Create(_PATH).Close();
            }
        }

        public List<string> LerTodasLinhasTexto(string _PATH)
        {

            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(_PATH))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void ReescreverTexto(string _PATH, List<string> linhas)
        {

            using (StreamWriter output = new StreamWriter(_PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}
