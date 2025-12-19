using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class FoodBookingsService
    {
        // Endpoint for the Food Bookings resource.
        const string FoodBookingsEndpoint = "api/FoodBookings";
        // Private HttpClient instance
        private readonly HttpClient _httpClient;
        public FoodBookingsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        // Gets all food bookings for a specific event.
        public async Task<IReadOnlyCollection<FoodBookingDTO>> GetFoodBookingsForEventAsync(int eventId)
        {
            // Send a GET request to retrieve food bookings for the specified event.
            var response = await _httpClient.GetAsync($"{FoodBookingsEndpoint}/ForEvent/{eventId}");
            // Ensure the response indicates success.
            response.EnsureSuccessStatusCode();

            // Read the response content as a string.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // If the response body is empty for some reason, also treat as no data.
            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return Array.Empty<FoodBookingDTO>();
            }

            // Deserialize the JSON response into a collection of FoodBookingDTO objects.
            var foodBookings = JsonSerializer.Deserialize<IReadOnlyCollection<FoodBookingDTO>>(jsonResponse, jsonOptions);

            // Validate the deserialized data.
            if (foodBookings == null)
            {
                throw new ArgumentNullException(nameof(foodBookings), "The food bookings API response is null");
            }
            return foodBookings;
        }

        // Async method to create a new food booking.
        public async Task CreateFoodBookingAsync(FoodBookingDTO foodBooking)
        {
            var response = await _httpClient.PostAsJsonAsync(FoodBookingsEndpoint, foodBooking);
            response.EnsureSuccessStatusCode();
        }
    }
}
