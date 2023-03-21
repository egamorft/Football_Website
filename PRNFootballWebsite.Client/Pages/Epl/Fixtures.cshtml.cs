using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Epl
{
    public class FixturesModel : PageModel
    {
        private readonly HttpClient client = null;
        private string DateTimeUrl = "";
        private string MatchesUrl = "";
        [BindProperty]
        public List<DateTime> ListDateTime { get; set; }
        [BindProperty]
        public List<MatchesDTO> ListMatches { get; set; }
        public FixturesModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            DateTimeUrl = "https://localhost:5000/api/Match/EplMatchDate";
            MatchesUrl = "https://localhost:5000/api/Match/EplMatches";
        }

        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            //List datetime
            var response_dt = await httpClient.GetAsync(DateTimeUrl);
            var content_dt = await response_dt.Content.ReadAsStringAsync();
            ListDateTime = JsonSerializer.Deserialize<List<DateTime>>(content_dt, options);
            //List datetime

            //List matches
            var response_matches = await httpClient.GetAsync(MatchesUrl);
            var content_matches = await response_matches.Content.ReadAsStringAsync();
            ListMatches = JsonSerializer.Deserialize<List<MatchesDTO>>(content_matches, options);
            //List matches

            return Page();

        }
    }
}
