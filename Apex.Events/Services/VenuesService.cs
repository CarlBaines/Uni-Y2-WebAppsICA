using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class VenuesService
    {
        // Endpoint for the Venues resource.
        const string VenuesEndpoint = "api/Venues";
        // Private HttpClient instance
        private readonly HttpClient _httpClient;
        // Constructor
        public VenuesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // JSON serialiser options
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        // Async method to fetch venue items.
        public async Task<List<VenueDto>> GetVenuesAsync()
        {
            // Send a GET request to the Venues endpoint.
            var response = await _httpClient.GetAsync(VenuesEndpoint);
            // Ensure the response indicates success.
            response.EnsureSuccessStatusCode();

            // Read the response content as a string.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialise the JSON response into a list of VenueDto
            var venues = JsonSerializer.Deserialize<List<VenueDto>>(jsonResponse, jsonOptions);

            // Validate the deserialised result
            if(venues == null)
            {
                throw new ArgumentNullException(nameof(response), "The venues api response is null");
            }
            return venues;
        }

        // Async method to fetch venue list items.
        public async Task<List<SelectListItem>> GetVenuesSelectListAsync()
        {
            // Fetch venues
            var venues = await GetVenuesAsync();
            // Convert to SelectListItem
            var selectList = new List<SelectListItem>();
            if(venues != null)
            {
                // Fetch and convert venues to SelectListItem
                selectList = venues.Select(v => new SelectListItem
                {
                    Value = v.Code,
                    Text = v.Name // Displayed text on the browser is the venue name.
                }).ToList();
            }
            return selectList;
        }
    }
}
