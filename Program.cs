using Newtonsoft.Json;

HttpClient client = new();
const string url = "https://pres.tsrealty.ru/testing.php";

var tsRealtyJson = await client.GetStringAsync(url);
var parsedJson = JsonConvert.DeserializeObject<Root>(tsRealtyJson);
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
    public Result? Result { get; set; }
}

public class Result
{
    public Dictionary<string, Values>? Fields { get; set; }
}

public class Values
{
    public string? Type { get; set; }
    public string? Title { get; set; }
}