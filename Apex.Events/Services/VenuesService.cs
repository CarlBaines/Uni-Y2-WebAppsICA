using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class VenuesService
    {
        // Endpoint for the Venues resource.
        const string VenuesEndpoint = "api/Venues";
        // Endpoint for the Availability resource.
        const string AvailabilityEndpoint = "api/Availability";
        // Endpoint for the Reservations resource.
        const string ReservationsEndpoint = "api/Reservations";
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

        // Async method to fetch a venue by its code.
        public async Task<VenueDto?> GetVenueByCodeAsync(string venueCode)
        {
            // Validate venue code
            if (string.IsNullOrWhiteSpace(venueCode))
            {
                return null;
            }
            // Fetch venues
            var venues = await GetVenuesAsync();
            return venues.FirstOrDefault(v => string.Equals(v.Code, venueCode));
        }

        // Async method to fetch a venue name by its code.
        public async Task<string?> GetVenueNameAsync(string venueCode)
        {
            var venue = await GetVenueByCodeAsync(venueCode);
            return venue?.Name;
        }

        // Async method to fetch the available suitable venues.
        //public async Task<IReadOnlyList<AvailabilityDTO>> GetAvailableSuitableVenuesAsync(
        //    string eventType,
        //    DateTime beginDate,
        //    DateTime? endDate = null)
        //{
        //    // Validate event type
        //    if (string.IsNullOrWhiteSpace(eventType))
        //    {
        //        throw new ArgumentNullException("Event type is required.", nameof(eventType));
        //    }
        //    // Construct query
        //    var query = $"eventType={Uri.EscapeDataString(eventType)}&beginDate={beginDate:yyyy-MM-dd}";
        //    // Check if the endDate parameter has a value
        //    if (endDate.HasValue)
        //    {
        //        query += $"&endDate={endDate.Value:yyyy-MM-dd}";
        //    }

        //    // Send the GET request to the Availability endpoint
        //    var response = await _httpClient.GetAsync($"{AvailabilityEndpoint}?{query}");
        //    response.EnsureSuccessStatusCode();

        //    var responseJson = await response.Content.ReadAsStringAsync();
        //    var availableVenues = JsonSerializer.Deserialize<List<AvailabilityDTO>>(responseJson, jsonOptions);

        //    if(availableVenues == null)
        //    {
        //        throw new ArgumentNullException(nameof(response), "The availability API response is null.");
        //    }

        //    return availableVenues;
        //}

        // Async method to reserve a venue
        //public async Task<ReservationGetDTO> ReserveVenueAsync(DateTime eventDate, string venueCode)
        //{
        //    // Validate venue code
        //    if (string.IsNullOrWhiteSpace(venueCode))
        //    {
        //        throw new ArgumentNullException("Venue code is required.", nameof(venueCode));
        //    }

        //    var reservationDTO = new ReservationPostDTO
        //    {
        //        EventDate = eventDate.Date,
        //        VenueCode = venueCode
        //    };

        //    var requestJson = JsonSerializer.Serialize(reservationDTO, jsonOptions);
        //    // Create the HTTP request content
        //    using var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //    // Send the POST request to the Reservations endpoint
        //    var response = await _httpClient.PostAsync(ReservationsEndpoint, content);
        //    response.EnsureSuccessStatusCode();

        //    var responseJson = await response.Content.ReadAsStringAsync();
        //    var reservation = JsonSerializer.Deserialize<ReservationGetDTO>(responseJson, jsonOptions);

        //    if(reservation == null)
        //    {
        //        throw new ArgumentNullException(nameof(response), "The reservations API response is null.");
        //    }

        //    return reservation;
        //}

        // Asnyc method to free a venue for a reservation
        //public async Task FreeReservationAsync(string reservationReference)
        //{
        //    // Validate reservation reference
        //    if (string.IsNullOrWhiteSpace(reservationReference))
        //    {
        //        throw new ArgumentNullException("Reservation reference is required.", nameof(reservationReference));
        //    }

        //    // Build the request URI
        //    var requestUri = $"{ReservationsEndpoint}/{Uri.EscapeDataString(reservationReference)}";

        //    // Send the DELETE request to the Reservations endpoint
        //    var response = await _httpClient.DeleteAsync(requestUri);

        //    // Check if response is successful or if not found since a 404 indicates the reservation is already freed
        //    if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        return;
        //    }

        //    var responseBody = await response.Content.ReadAsStringAsync();
        //    throw new InvalidOperationException($"Failed to free reservation. Status Code: {response.StatusCode}, Response: {responseBody}");
        //}

        // Async method to free old reservation and reserve a new venue
        //public async Task<ReservationGetDTO> ChangeVenueReservationAsync(
        //    string eventType,
        //    DateTime eventDate,
        //    string? currentVenueCode,
        //    string? newVenueCode)
        //{
        //    // Validate event type
        //    if (string.IsNullOrWhiteSpace(eventType))
        //    {
        //        throw new ArgumentNullException(nameof(eventType), "Event type is required.");
        //    }
        //    // Validate new venue code
        //    if (string.IsNullOrWhiteSpace(newVenueCode))
        //    {
        //        throw new ArgumentNullException(nameof(newVenueCode), "New venue code is required.");
        //    }

        //    // Check if the event currently has a reserved venue code and if the user selected the same venue again.
        //    if(!string.IsNullOrWhiteSpace(currentVenueCode) && string.Equals(currentVenueCode, newVenueCode, StringComparison.OrdinalIgnoreCase))
        //    {
        //        return await GetReservationAsync($"{currentVenueCode}{eventDate:yyyyMMdd}");
        //    }

        //    // Check if requested venue is available and suitable.
        //    var available = await GetAvailableSuitableVenuesAsync(eventType, eventDate.Date);
        //    // Validate availability
        //    var forReserve = available.Any(a => string.Equals(a.Code, newVenueCode, StringComparison.OrdinalIgnoreCase));
        //    if (!forReserve)
        //    {
        //        throw new InvalidOperationException("The requested venue is not available/suitable for this event.");
        //    }

        //    // Free current reservation if it exists
        //    if (!string.IsNullOrWhiteSpace(currentVenueCode))
        //    {
        //        var currentReference = $"{currentVenueCode}{eventDate:yyyyMMdd}";
        //        await FreeReservationAsync(currentReference);
        //    }

        //    // Now that the venue has been freed if needed, a new venue can be reserved.
        //    return await ReserveVenueAsync(eventDate, newVenueCode);
        //}

        //// Private async method to get reservation by reference.
        //private async Task<ReservationGetDTO> GetReservationAsync(string reference)
        //{
        //    var response = await _httpClient.GetAsync($"{ReservationsEndpoint}/{Uri.EscapeDataString(reference)}");
        //    response.EnsureSuccessStatusCode();

        //    var responseJson = await response.Content.ReadAsStringAsync();
        //    var reservation = JsonSerializer.Deserialize<ReservationGetDTO>(responseJson, jsonOptions);

        //    if(reservation == null)
        //    {
        //        throw new ArgumentNullException(nameof(response), "The reservations API response is null.");
        //    }

        //    return reservation;
        //}
    }
}
