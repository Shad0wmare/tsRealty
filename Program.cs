using Newtonsoft.Json.Linq;

HttpClient client = new();
const string url = "https://pres.tsrealty.ru/testing.php";


var tsRealtyJson = await client.GetStringAsync(url);
JObject parsedJson = JObject.Parse(tsRealtyJson);
JObject fields = (JObject)parsedJson["result"]!["fields"]!;

var query = fields.Properties().Select(n => new { Name = n.Name,
                                                  Type = n.Children().Select(t => t["type"]!).First().Value<string>(),
                                                  Title = n.Children().Select(t => t["title"]!).First().Value<string>() });

foreach (var data in query)
{
    if (data.Type == "enumeration")
    {
        Console.WriteLine($"Поле: {data.Name} имеет название: {data.Title} и является полем типа enumeration");
    }
}
