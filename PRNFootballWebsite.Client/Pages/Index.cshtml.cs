using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.DTO;
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
        private string FourMatchesApiUrl = "";
        [BindProperty]
        public MatchesDTO FirstUpcomingMatch { get; set; }
        [BindProperty]
        public List<MatchesDTO> NextUpcomingMatch { get; set; }
        [BindProperty]
        public List<TournamentDTO> Tournaments { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MatchesApiUrl = "https://localhost:5000/api/Match/FirstUpcomingMatch";
            TournamentsApiUrl = "https://localhost:5000/api/Tournament";
            FourMatchesApiUrl = "https://localhost:5000/api/Match/NextUpcomingMatches";
        }
        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            //Get first upcoming match
            var response_fum = await httpClient.GetAsync(MatchesApiUrl);
            var content_fum = await response_fum.Content.ReadAsStringAsync();
            FirstUpcomingMatch = JsonSerializer.Deserialize<MatchesDTO>(content_fum, options);
            //Get first upcoming match

            //Get list tournaments
            var response_tour = await httpClient.GetAsync(TournamentsApiUrl);
            var content_tour = await response_tour.Content.ReadAsStringAsync();
            Tournaments = JsonSerializer.Deserialize<List<TournamentDTO>>(content_tour, options);
            //Get list tournaments

            //Get next four coming matches
            var response_nfcm = await httpClient.GetAsync(FourMatchesApiUrl);
            var content_nfcm = await response_nfcm.Content.ReadAsStringAsync();
            NextUpcomingMatch = JsonSerializer.Deserialize<List<MatchesDTO>>(content_nfcm, options);
            //Get next four coming matches

            return Page();

        }
    }
}
