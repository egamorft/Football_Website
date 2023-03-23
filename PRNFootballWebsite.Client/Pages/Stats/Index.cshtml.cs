using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string SpecificStatisticUrl = "";
        private string SpecificScorerUrl = "";
        [BindProperty]
        public StatisticDTO StatisticData { get; set; }
        [BindProperty]
        public List<MatchScorerDTO> StatisticScorer { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SpecificStatisticUrl = "https://localhost:5000/api/Statistic/";
            SpecificScorerUrl = "https://localhost:5000/api/Scorer/";

        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            SpecificStatisticUrl += id;
            SpecificScorerUrl += id;

            //List specific match stats
            var response_stats = await httpClient.GetAsync(SpecificStatisticUrl);
            var content_stats = await response_stats.Content.ReadAsStringAsync();
            StatisticData = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
            //List specific match stats

            //List specific scorer
            var response_scorer = await httpClient.GetAsync(SpecificScorerUrl);
            var content_scorer = await response_scorer.Content.ReadAsStringAsync();
            StatisticScorer = JsonSerializer.Deserialize<List<MatchScorerDTO>>(content_scorer, options);
            //List specific scorer

            return Page();
        }
    }
}
