namespace RedeSevice.Models
{
    public class Imagem
    {
        string PATH = "/";

        public async Task BaixarImagem()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://redeservice.com.br/wp-content/uploads/2020/07/redeservice-logo.png");

            using (var fs = new FileStream(PATH + "redeservice-logo.png", FileMode.CreateNew))
            {
                var result = response.Content.CopyToAsync(fs);
                result.Wait();
            }
        }

        public string EncodarImagem()
        {

            var imagem = File.ReadAllBytes(PATH + "redeservice-logo.png");
            File.Delete(PATH + "redeservice-logo.png");

            return "data:image/png;charset=utf-8;base64," + Convert.ToBase64String(imagem);
        }
    }
}
