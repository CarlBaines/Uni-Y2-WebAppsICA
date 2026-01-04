using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class MenuService
    {
        private readonly HttpClient _httpClient;
        // Endpoint for fetching menu data.
        private const string MenusEndpoint = "api/GetMenu";

        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        // Async method to fetch menu items.
        public async Task<List<MenuDTO>> GetMenusAsync()
        {
            // Make an HTTP GET request to fetch menu data.
            var response = await _httpClient.GetAsync(MenusEndpoint);
            response.EnsureSuccessStatusCode();

            // Read and deserialize the JSON response.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var menus = JsonSerializer.Deserialize<List<MenuDTO>>(jsonResponse, jsonOptions);

            // Check for null and throw an exception if necessary.
            if (menus == null)
            {
                throw new ArgumentNullException(nameof(response), "The menus response is null");
            }
            return menus;
        }

        // Async method to fetch menu type list items.
        public async Task<List<SelectListItem>> GetMenuTypesSelectListAsync()
        {
            // Fetch menus using method above.
            var menus = await GetMenusAsync();
            // Convert to SelectListItem format.
            var selectList = new List<SelectListItem>();
            // Populate the select list if menus are available.
            if (menus != null)
            {
                selectList = menus.Select(m => new SelectListItem
                {
                    Value = m.MenuId.ToString(),
                    Text = m.MenuName
                }).ToList();
            }
            return selectList;
        }

    }
}
