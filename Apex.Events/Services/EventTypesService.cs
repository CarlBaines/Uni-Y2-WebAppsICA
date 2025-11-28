using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class EventTypesService
    {
        // Endpoint for the Event Types resource.
        const string EventTypesEndpoint = "api/EventTypes";
        // Private HttpClient instance
        private readonly HttpClient _httpClient;
        // Constructor
        public EventTypesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // JSON serialiser options
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        // Async method to fetch event type items.
        public async Task<List<EventTypesDTO>> GetEventTypesAsync()
        {
            // Send a GET request to the Event Types endpoint
            var response = await _httpClient.GetAsync(EventTypesEndpoint);
            // Ensure the response indicates success
            response.EnsureSuccessStatusCode();

            // Read the response content as a string
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a list of EventTypesDTO
            var eventTypes = JsonSerializer.Deserialize<List<EventTypesDTO>>(jsonResponse, jsonOptions);

            // Validating the deserialized result
            if(eventTypes == null)
            {
                throw new ArgumentNullException(nameof(response), "The Event types response is null");
            }
            return eventTypes; 
        }

        // Async method to fetch event type list items.
        public async Task<List<SelectListItem>> GetEventTypesSelectListAsync()
        {
            // Fetch event types
            var eventTypes = await GetEventTypesAsync();
            // Convert to SelectListItem
            var selectList = new List<SelectListItem>();
            if(eventTypes != null)
            {
                selectList = eventTypes.Select(et => new SelectListItem
                {
                    Value = et.Id,
                    Text = et.Title
                }).ToList();
            }
            return selectList;
        }
    }
}
