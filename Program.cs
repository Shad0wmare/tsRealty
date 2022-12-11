using System.Text.Json;
using tsRealty;
using System.Text.Json.Nodes;

using HttpClient client = new();

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var tsRealtyJson = await client.GetStringAsync("https://pres.tsrealty.ru/testing.php");

    JsonNode tsRealtyNode = JsonNode.Parse(tsRealtyJson)!;
    JsonObject fieldsObject = tsRealtyNode["result"]!["fields"]!.AsObject();
    
    var stream = new MemoryStream();
    var writer = new Utf8JsonWriter(stream);
    fieldsObject.WriteTo(writer);
    writer.Flush();
    
    var fields = JsonSerializer.Deserialize<Result>(stream.ToArray());

    foreach (var field in fields)
    {
        if (field.Value.Type == "enumeration")
        {
            Console.WriteLine($"Поле: {field.Key} имеет название {field.Value.Title} и является полем типа enumeration");
            
            await DateBaseImitation();
            Task DateBaseImitation()
            {
                Console.WriteLine($"Поле: {field.Key} добавлено в базу данных");
                return Task.CompletedTask;
            }
        }
    }
}

