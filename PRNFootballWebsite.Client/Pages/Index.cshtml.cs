using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRNFootballWebsite.API.DTO;
//using PRNFootballWebsite.Client.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PRNFootballWebsite.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MatchesApiUrl = "";
        private string TournamentsApiUrl = "";
        [BindProperty]
        public MatchesDTO UpcomingMatch { get; set; }
        [BindProperty]
        public List<TournamentDTO> Tournaments { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MatchesApiUrl = "https://localhost:5000/api/Match/UpcomingMatch";
            TournamentsApiUrl = "https://localhost:5000/api/Tournament";
        }
        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(MatchesApiUrl);
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            UpcomingMatch = JsonSerializer.Deserialize<MatchesDTO>(content, options);

            var response_tour = await httpClient.GetAsync(TournamentsApiUrl);
            var content_tour = await response_tour.Content.ReadAsStringAsync();
            Tournaments = JsonSerializer.Deserialize<List<TournamentDTO>>(content_tour, options);
            return Page();

        }
    }
}
