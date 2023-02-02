using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPhone.DTO.DTOs;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MyPhone.UI.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EditModel> _logger;
        private JsonSerializerOptions _options;

        [BindProperty]
        public PersonUpdateDTO PersonDTO { get; set; }

        public EditModel(HttpClient httpClient, ILogger<EditModel> logger)
        {
            _logger = logger;

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7238/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGet(int ID)
        {
            var response = await _httpClient.GetAsync($"person/{ID}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                PersonDTO resultDTO = await JsonSerializer.DeserializeAsync<PersonDTO>(content, _options).ConfigureAwait(false);

                PersonDTO = new PersonUpdateDTO() { ID = resultDTO.ID, Name = resultDTO.Name, DateOfBirth = resultDTO.DateOfBirth };
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var person = new StringContent(JsonSerializer.Serialize(PersonDTO), Encoding.UTF8, Application.Json);

            using var response = await _httpClient.PutAsync($"person/{PersonDTO.ID}", person).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
