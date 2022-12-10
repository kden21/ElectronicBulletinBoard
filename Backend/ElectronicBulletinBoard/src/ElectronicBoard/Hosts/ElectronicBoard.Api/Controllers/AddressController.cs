using System.Net;
using System.Net.Mime;
using System.Text;
using ElectronicBoard.AppServices.Address.Services;
using ElectronicBoard.Contracts.Advt.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

[ApiController]
[Route("v1/address")]
public class AddressController: ControllerBase
{
    private const string AddressToken = "AddressToken";
    private const string AddressApiUrl = "AddressApiUrl";
    private readonly IAddressService _addressService;
    
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
   
    [HttpGet("getSuggestions", Name = "GetSuggestions")]
    public async Task<IActionResult> GetSuggestions([FromQuery] string? cityName, CancellationToken cancellation)
    {
        return Ok(await _addressService.GetSuggestions(cityName, cancellation));
    }
    
    [HttpGet("getById", Name = "GetById")]
    public async Task<IActionResult> GetAddressById([FromQuery] string? cityFiasId, CancellationToken cancellation)
    {
        return Ok(await _addressService.GetAddressById(cityFiasId, cancellation));
    }
}