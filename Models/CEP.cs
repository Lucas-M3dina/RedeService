using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace RedeSevice.Models
{
    public class CEP
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }



        public async Task<CEP> BuscarCep(string cep)
        {
            if (cep != null && cep != "")
            {
                HttpClient httpClient = new();
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var jsonString = await response.Content.ReadAsStringAsync();
                CEP objetoCep = JsonConvert.DeserializeObject<CEP>(jsonString);

                return objetoCep;
            }
            else
            {
                return new CEP();
            }

            
            
        }

    }
}
