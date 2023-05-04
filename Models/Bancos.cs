using Newtonsoft.Json;

namespace RedeSevice.Models
{
    public class Bancos
    {

        public string? ispb { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? fullName { get; set; }



        public async Task<List<Bancos>> ListarBancos()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync($"https://brasilapi.com.br/api/banks/v1");
            var jsonString = await response.Content.ReadAsStringAsync();
            List<Bancos> listaBancos = JsonConvert.DeserializeObject<List<Bancos>>(jsonString);

            return listaBancos;
           
        }
    }
}
