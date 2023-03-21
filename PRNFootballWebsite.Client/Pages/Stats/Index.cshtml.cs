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
        [BindProperty]
        public StatisticDTO StatisticData { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SpecificStatisticUrl = "https://localhost:5000/api/Statistic/";
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

            //List specific match stats
            var response_stats = await httpClient.GetAsync(SpecificStatisticUrl);
            var content_stats = await response_stats.Content.ReadAsStringAsync();
            StatisticData = JsonSerializer.Deserialize<StatisticDTO>(content_stats, options);
            //List specific match stats

            return Page();
        }
    }
}
