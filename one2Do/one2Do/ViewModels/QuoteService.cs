using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace one2Do;

public class QuoteService

{
    private readonly HttpClient _httpClient;

    public QuoteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InspirationalQuote[]> GetQuotesAsync()
    {
        var response = await _httpClient.GetStringAsync("https://type.fit/api/quotes");
        var quotes = JsonSerializer.Deserialize<InspirationalQuote[]>(response);
        // Console.WriteLine(response);
        // Console.WriteLine(quotes);
        // Console.WriteLine(quotes[1].text);

        // Console.WriteLine(quotes);

        return quotes;
    }
}

public class InspirationalQuote
{
    public string text { get; set; }
    public string? id { get; set; }
    public string author { get; set; }

}

