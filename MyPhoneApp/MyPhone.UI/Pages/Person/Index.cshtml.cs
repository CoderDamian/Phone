using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPhone.DTO.DTOs;
using System.Text.Json;

namespace MyPhone.UI.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;

        [BindProperty]
        public IEnumerable<PersonDTO>? PersonDTO { get; set; }

        public IndexModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://localhost:7238/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await _httpClient.GetAsync("Person").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                PersonDTO = await JsonSerializer.DeserializeAsync<IEnumerable<PersonDTO>>(content, _serializerOptions).ConfigureAwait(false);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int ID)
        {
            using var response = await _httpClient.DeleteAsync($"person/{ID}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return RedirectToPage();
        }
    }
}
