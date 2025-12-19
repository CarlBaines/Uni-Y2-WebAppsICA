using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;
using System.Text.Json;

namespace Apex.Events.Services
{
    public class MenuService
    {
        private readonly HttpClient _httpClient;
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
            var response = await _httpClient.GetAsync(MenusEndpoint);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var menus = JsonSerializer.Deserialize<List<MenuDTO>>(jsonResponse, jsonOptions);

            if(menus == null)
            {
                throw new ArgumentNullException(nameof(response), "The menus response is null");
            }
            return menus;
        }

        // Async method to fetch menu type list items.
        public async Task<List<SelectListItem>> GetMenuTypesSelectListAsync()
        {
            var menus = await GetMenusAsync();
            var selectList = new List<SelectListItem>();
            if(menus != null)
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
