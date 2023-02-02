using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPhone.DTO.DTOs;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MyPhone.UI.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        [BindProperty]
        public PersonCreateDTO PersonDTO { get; set; }

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7238/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var person = new StringContent(JsonSerializer.Serialize(PersonDTO), Encoding.UTF8, Application.Json);

            using var respone = await _httpClient.PostAsync("person", person).ConfigureAwait(false);

            respone.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
