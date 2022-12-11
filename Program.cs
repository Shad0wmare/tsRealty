using System.Text.Json;

using HttpClient client = new();

var repos = await ProcessRepositoriesAsyncStream(client);
foreach (var repo in repos)
{
    Console.WriteLine(repo);
}

static async Task<Dictionary<string, object>> ProcessRepositoriesAsyncStream(HttpClient client)
{
    await using Stream stream = await client.GetStreamAsync("https://pres.tsrealty.ru/testing.php");
    var tsRealtyJson = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stream);
    return tsRealtyJson ?? new();
}

