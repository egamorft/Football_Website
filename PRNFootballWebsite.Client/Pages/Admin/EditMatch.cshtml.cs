using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PRNFootballWebsite.Client.Pages.Admin
{
    public class EditMatchModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MatchStatsUrl = "";
        [BindProperty]
        public StatisticDTO MatchStats { get; set; }

        public EditMatchModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MatchStatsUrl = "https://localhost:5000/api/Statistic/";
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            MatchStatsUrl += id;

            //List specific match stats
            var response_stats = await httpClient.GetAsync(MatchStatsUrl);
            var content_stats = await response_stats.Content.ReadAsStringAsync();
            MatchStats = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
            //List specific match stats

            return Page();

        }
        public async Task<IActionResult> OnPostFinishedAsync()
        {
            var httpClient = new HttpClient();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string jwt = Request.Cookies["jwt"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var data = JsonConvert.SerializeObject(MatchStats);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:5000/api/Statistic/Edit/" + MatchStats.MatchId, content);
            if (response.IsSuccessStatusCode)
            {
                if(MatchStats.Team1Goal > 0 || MatchStats.Team2Goal > 0)
                {
                    return RedirectToPage("/Admin/GoalScorer", new { stats_id = MatchStats.StatisticId });
                }
                else
                {
                    return RedirectToPage("/Admin/ManageMatches");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");

                MatchStatsUrl += MatchStats.MatchId;

                //List specific match stats
                var response_stats = await httpClient.GetAsync(MatchStatsUrl);
                var content_stats = await response_stats.Content.ReadAsStringAsync();
                MatchStats = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
                //List specific match stats
                return Page();
            }
        }
    }
}
