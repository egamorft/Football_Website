using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Fixture
{
    public class todayModel : PageModel
    {
        private readonly HttpClient client = null;
        private string TodayMatchUp = "";
        private string TodayTournament = "";
        [BindProperty]
        public List<MatchesDTO> ListTodayMatches { get; set; }
        [BindProperty]
        public List<TournamentDTO> ListTodayTournaments { get; set; }
        public todayModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TodayMatchUp = "https://localhost:5000/api/Match/TodayMatchUp";
            TodayTournament = "https://localhost:5000/api/Match/TodayTournament";
        }
        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            //List today matches
            var response_tmu = await httpClient.GetAsync(TodayMatchUp);
            var content_tmu = await response_tmu.Content.ReadAsStringAsync();
            ListTodayMatches = JsonSerializer.Deserialize<List<MatchesDTO>>(content_tmu, options);
            //List today matches

            //List today tournament
            var response_tt = await httpClient.GetAsync(TodayTournament);
            var content_tt = await response_tt.Content.ReadAsStringAsync();
            ListTodayTournaments = JsonSerializer.Deserialize<List<TournamentDTO>>(content_tt, options);
            //List today matches

            return Page();

        }
    }
}
