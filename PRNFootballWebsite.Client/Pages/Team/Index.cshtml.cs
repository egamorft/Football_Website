using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Team
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string TeamData = "";
        private string ListTeamMatches = "";
        private string ListTeamPlayers = "";
        private string ListTeamResults = "";
        [BindProperty]
        public TeamDTO ListTeams { get; set; }
        [BindProperty]
        public List<MatchesDTO> ListMatches { get; set; }
        [BindProperty]
        public List<PlayerDTO> ListPlayers { get; set; }
        [BindProperty]
        public List<MatchesDTO> ListResults { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TeamData = "https://localhost:5000/api/Team/";
            ListTeamMatches = "https://localhost:5000/api/Match/NextMatches/";
            ListTeamPlayers = "https://localhost:5000/api/Player/Team/";
            ListTeamResults = "https://localhost:5000/api/Match/ResultMatches/Team/";

        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            TeamData += id;
            ListTeamMatches += id;
            ListTeamPlayers += id;
            ListTeamResults += id;

            //List specific team
            var response_teams = await httpClient.GetAsync(TeamData);
            var content_teams = await response_teams.Content.ReadAsStringAsync();
            ListTeams = JsonSerializer.Deserialize<TeamDTO>(content_teams, options);
            //List specific team

            //List team upcoming matches
            var response_matches = await httpClient.GetAsync(ListTeamMatches);
            var content_matches = await response_matches.Content.ReadAsStringAsync();
            ListMatches = JsonSerializer.Deserialize<List<MatchesDTO>>(content_matches, options);
            //List team upcoming matches

            //List team players
            var response_players = await httpClient.GetAsync(ListTeamPlayers);
            var content_players = await response_players.Content.ReadAsStringAsync();
            ListPlayers = JsonSerializer.Deserialize<List<PlayerDTO>>(content_players, options);
            //List team players

            //List team results
            var response_results = await httpClient.GetAsync(ListTeamResults);
            var content_results = await response_results.Content.ReadAsStringAsync();
            ListResults = JsonSerializer.Deserialize<List<MatchesDTO>>(content_results, options);
            //List team results

            return Page();
        }
    }
}
