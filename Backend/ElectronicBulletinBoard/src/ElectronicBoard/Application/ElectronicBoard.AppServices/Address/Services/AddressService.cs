using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using Dadata;
using Dadata.Model;
using ElectronicBoard.Contracts.DaData;
using Microsoft.Extensions.Configuration;

namespace ElectronicBoard.AppServices.Address.Services;

public class AddressService:IAddressService
{
    private readonly string _token;
    private readonly ISuggestClientAsync _suggestClientAsync;

    public AddressService(IConfiguration configuration, ISuggestClientAsync suggestClientAsync)
    {
        _suggestClientAsync = suggestClientAsync;
        _token = configuration.GetSection("Address").GetSection("AddressToken").Value;
    }
    
    /// <inheritdoc />
    public async Task<List<Contracts.DaData.Address>> GetSuggestions(string? cityName, CancellationToken cancellation)
    {
        var request = new SuggestAddressRequest(cityName, 10)
        {
            from_bound = new AddressBound("city"),
            to_bound = new AddressBound("city")
        
        };
        var response = await _suggestClientAsync.SuggestAddress(request, cancellation);
        return response.suggestions.Select(x =>new Contracts.DaData.Address()
        {
            CityName = x.data.city,
            CityFias = x.data.city_fias_id
        }).ToList();
    }
    
    /// <inheritdoc />
    public async Task<string> GetAddressById(string? cityFiasId, CancellationToken cancellation)
    {
        var request = new SuggestAddressRequest(cityFiasId)
        {
            from_bound = new AddressBound("city"),
            to_bound = new AddressBound("city")
        
        };
        var response = await _suggestClientAsync.FindAddress(cityFiasId, cancellation);
        return response.suggestions[0].data.city;
    }
}

