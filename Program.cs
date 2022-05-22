using HtmlAgilityPack;
using WebCrawlingPoc;

await startCrawlerasync();
Console.ReadLine();

static async Task startCrawlerasync()
{
    var url = "https://sp.olx.com.br/baixada-santista-e-litoral-sul/regiao-de-santos/praia-grande/autos-e-pecas/motos/250";
    var cliente = new HttpClient();
    var html = await cliente.GetStringAsync(url);
    var htmlDocumento = new HtmlDocument();
    htmlDocumento.LoadHtml(html);

    var motos = new List<Moto>();

    var divs = htmlDocumento.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "")
    .Equals("h3us20-6 dQYDAH")).ToList();

    foreach (var div in divs)
    {
        var moto = new Moto();
        moto.Modelo = div.Descendants("h2").FirstOrDefault().ChildAttributes("title").FirstOrDefault().Value;
        moto.Preco = div.Descendants("span").FirstOrDefault().ChildAttributes("aria-label").FirstOrDefault().Value; // ta pegando a quantidade de fotos do anuncio
        moto.Link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
        moto.ImagemUrl = div.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;
        motos.Add(moto);
    }
}