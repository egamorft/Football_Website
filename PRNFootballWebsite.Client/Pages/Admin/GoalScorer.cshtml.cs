using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PRNFootballWebsite.Client.Pages.Admin
{
    public class GoalScorerModel : PageModel
    {
        private readonly HttpClient client = null;
        private string PlayersUrl = "";
        private string ScorerUrl = "";
        private string StatsUrl = "";
        [BindProperty]
        public List<PlayerDTO> ListTeamsPlayer { get; set; }
        [BindProperty]
        public List<MatchScorerDTO> ListGoalScorer { get; set; }
        [BindProperty]
        public StatisticDTO MatchStats { get; set; }

        public GoalScorerModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PlayersUrl = "https://localhost:5000/api/Player/MatchPlayers/";
            ScorerUrl = "https://localhost:5000/api/Scorer/";
            StatsUrl = "https://localhost:5000/api/Statistic/Stats/";
        }

        public async Task<IActionResult> OnGetAsync(int stats_id)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            PlayersUrl += stats_id;
            ScorerUrl += stats_id;
            StatsUrl += stats_id;

            //List match players
            var response_players = await httpClient.GetAsync(PlayersUrl);
            var content_players = await response_players.Content.ReadAsStringAsync();
            ListTeamsPlayer = JsonSerializer.Deserialize<List<PlayerDTO>>(content_players, options);
            //List match players

            //List match scorers
            var response_scorer = await httpClient.GetAsync(ScorerUrl);
            var content_scorer = await response_scorer.Content.ReadAsStringAsync();
            ListGoalScorer = JsonSerializer.Deserialize<List<MatchScorerDTO>>(content_scorer, options);
            //List match scorers

            //List match players
            var response_stats = await httpClient.GetAsync(StatsUrl);
            var content_stats = await response_stats.Content.ReadAsStringAsync();
            MatchStats = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
            //List match players

            return Page();

        }

        public async Task<IActionResult> OnPostFinishedAsync(List<MatchScorerDTO> listGoalScorer)
        {
            var httpClient = new HttpClient();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string jwt = Request.Cookies["jwt"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var response = await httpClient.DeleteAsync("https://localhost:5000/api/Scorer/DeleteAll/" + MatchStats.StatisticId);
            if (response.IsSuccessStatusCode)
            {
                foreach (MatchScorerDTO matchScorer in listGoalScorer)
                {
                    var data = JsonConvert.SerializeObject(matchScorer);
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response_post = await httpClient.PostAsync("https://localhost:5000/api/Scorer/AddNew", content);
                    if(!response_post.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError(string.Empty, "Something went wrong");
                        return Page();
                    }
                }

                return RedirectToPage("/Admin/ManageMatches");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");

                PlayersUrl += MatchStats.StatisticId;
                ScorerUrl += MatchStats.StatisticId;
                StatsUrl += MatchStats.StatisticId;

                //List match players
                var response_players = await httpClient.GetAsync(PlayersUrl);
                var content_players = await response_players.Content.ReadAsStringAsync();
                ListTeamsPlayer = JsonSerializer.Deserialize<List<PlayerDTO>>(content_players, options);
                //List match players

                //List match scorers
                var response_scorer = await httpClient.GetAsync(ScorerUrl);
                var content_scorer = await response_scorer.Content.ReadAsStringAsync();
                ListGoalScorer = JsonSerializer.Deserialize<List<MatchScorerDTO>>(content_scorer, options);
                //List match scorers

                //List match players
                var response_stats = await httpClient.GetAsync(StatsUrl);
                var content_stats = await response_stats.Content.ReadAsStringAsync();
                MatchStats = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
                //List match players

                return Page();
            }
        }
    }
}
