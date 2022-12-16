using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient client = new();
const string url = "https://pres.tsrealty.ru/testing.php";

var tsRealtyJson = await client.GetStringAsync(url);
var parsedJson = JsonSerializer.Deserialize<Root>(tsRealtyJson);
foreach (var field in parsedJson!.Result!.Fields!)
{
    Task<string> DataBaseImitation()
    {
        string addResult = $"Поле {field.Key} добавлено в базу данных";
        return Task.FromResult(addResult);
    }
    
    if (field.Value.Type == "enumeration")
    {
        Console.WriteLine($"Поле: {field.Key}, имеет название: {field.Value.Title} и является полем типа {field.Value.Type}");
        Console.WriteLine(await DataBaseImitation());
    }
}

public class Root
{
    [JsonPropertyName("result")] public Result? Result { get; set; }
}

public class Result
{
    [JsonPropertyName("fields")] public Dictionary<string, Values>? Fields { get; set; }
}

public class Values
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
}