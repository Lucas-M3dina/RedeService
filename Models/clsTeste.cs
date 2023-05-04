using Newtonsoft.Json;

namespace RedeSevice.Models
{
    public class clsTeste : BaseTexto
    {
        public int codigo { get; set; }
        public DateTime descricao { get; set; }

        private const string PATH = "./data.json";



        public clsTeste()
        {
            CriarArquivo(PATH);
        }


        private string PrepararLinha(clsTeste cls)
        {
            // [{"codigo":0,"descricao":"2023/05/04 16:16:04.628"}
            return $"   {{\n        \"Codigo\" : {cls.codigo},\n        \"Descricao\" : \"{cls.descricao}\" \n   }},";
        }

        public void Criar()
        {
            Deletar();

            string[] linha1 = { "[" };
            File.AppendAllLines(PATH, linha1);

            for (int i = 0; i < 100; i++)
            {
                clsTeste cls = new();
                cls.codigo = i;
                cls.descricao = DateTime.Now;
                if (i == 99)
                {
                    string[] semVirgula = PrepararLinha(cls).Split(",");

                    string[] linha = { $"{semVirgula[0]},{semVirgula[1]}" };

                    File.AppendAllLines(PATH, linha);
                }
                else
                {
                    string[] linha = { PrepararLinha(cls) };
                    File.AppendAllLines(PATH, linha);
                }
                
            }
            string[] Ultimalinha = { "]" };
            File.AppendAllLines(PATH, Ultimalinha);

        }

        public List<clsTeste> LerTodos()
        {
            var json = File.ReadAllText(PATH);

            var cls = JsonConvert.DeserializeObject<List<clsTeste>>(json);

            return cls;
            
        }


        public void Deletar()
        {
            List<string> linhas = new();
            ReescreverTexto(PATH, linhas);
        }

    }
}

