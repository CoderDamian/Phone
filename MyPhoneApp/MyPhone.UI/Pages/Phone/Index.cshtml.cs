using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPhone.DTO.DTOs;
using System.Text.Json;

namespace MyPhone.UI.Pages.Phone
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _options;

        [BindProperty]
        public IEnumerable<PhoneDTO> PhonesDTO { get; set; }

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7238/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await _httpClient.GetAsync("phone").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                PhonesDTO = await JsonSerializer.DeserializeAsync<IEnumerable<PhoneDTO>>(content, _options).ConfigureAwait(false);
            }

            return Page();
        }
    }
}
