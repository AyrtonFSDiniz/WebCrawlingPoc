namespace WebCrawlingPoc
{
    public class Moto
    {
        
        public string Modelo { get; set; }
        public string Preco { get; set; }
        public string Link { get; set; }
        public string ImagemUrl { get; set; }

        public Moto()
        {
        }

        public Moto(string modelo, string preco, string link, string imagemUrl)
        {
            Modelo = modelo;
            Preco = preco;
            Link = link;
            ImagemUrl = imagemUrl;
        }
    }
}
