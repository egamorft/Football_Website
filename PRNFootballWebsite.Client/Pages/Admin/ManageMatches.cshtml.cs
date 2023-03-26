using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Admin
{
    public class ManageMatchesModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MatchesUrl = "";
        private string MatchStatsUrl = "";
        [BindProperty]
        public MatchesPaginateResponse ListAllMatches { get; set; }
        [BindProperty]
        public List<StatisticDTO> MatchStats { get; set; }
        public ManageMatchesModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MatchesUrl = "https://localhost:5000/api/Match/Paging/";
            MatchStatsUrl = "https://localhost:5000/api/Statistic/All";


        }
        public async Task<IActionResult> OnGetAsync(int p = 1, int s = 4, string txtSearch = null, string txtFilter = null)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            if(txtFilter != null && txtFilter != "")
            {
                if(txtSearch != null)
                {
                    MatchesUrl += p + "/" + s + "?txtSearch=" + txtSearch + "&txtFilter=" + txtFilter;
                }
                else
                {
                    MatchesUrl += p + "/" + s + "?txtFilter=" + txtFilter;
                }
            }
            else
            {
                if(txtSearch != null)
                {
                    MatchesUrl += p + "/" + s + "?txtSearch=" + txtSearch;
                }
                else
                {
                    MatchesUrl += p + "/" + s;
                }

            }

            //List all matches
            var response_all = await httpClient.GetAsync(MatchesUrl);
            var content_all = await response_all.Content.ReadAsStringAsync();
            ListAllMatches = JsonSerializer.Deserialize<MatchesPaginateResponse>(content_all, options);
            //List all matches

            //List stats match
            var response_stats = await httpClient.GetAsync(MatchStatsUrl);
            var content_stats = await response_stats.Content.ReadAsStringAsync();
            MatchStats = JsonSerializer.Deserialize<List<StatisticDTO>>(content_stats, options);
            //Liststats match

            return Page();

        }
    }
}
