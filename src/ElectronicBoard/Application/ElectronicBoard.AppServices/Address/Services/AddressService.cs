using System.Net.Mime;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ElectronicBoard.AppServices.Address.Services;

public class AddressService:IAddressService
{
    private readonly HttpClient _client = new HttpClient();
    private readonly string _token;

    public AddressService(IConfiguration configuration)
    {
        _token = configuration.GetSection("Address").GetSection("AddressToken").Value;
    }
    
    public async Task<string> GetSuggestions(string? cityName, CancellationToken cancellation)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization",$"Token {_token}");
        string body = "{\"query\":\"" + cityName + "\",\"from_bound\":{\"value\":\"city\"},\"to_bound\":{\"value\":\"city\"}}";
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address"),
            Content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json),
        };
        
        var response = await client.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
    
    public async Task<string> GetAddressById(string? cityFiasId, CancellationToken cancellation)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization",$"Token {_token}");
        string body = "{\"query\": \"9120b43f-2fae-4838-a144-85e43c2bfb29\"}";
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/address"),
            Content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json),
        };
        
        var response = await client.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}

