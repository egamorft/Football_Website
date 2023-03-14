using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRNFootballWebsite.Client.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PRNFootballWebsite.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MatchesApiUrl = "";
        [BindProperty]
        public MatchInfo UpcomingMatch { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MatchesApiUrl = "https://localhost:5000/api/Match/UpcomingMatch";
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
            UpcomingMatch = JsonSerializer.Deserialize<MatchInfo>(content, options);
            return Page();

        }
        public class MatchInfo
        {
            public int Matches_ID { get; set; }
            public DateTime DateTime { get; set; }
            public string Stadium { get; set; }
            public string Tournament_Name { get; set; }
            public string Team1_Name { get; set; }
            public string Team2_Name { get; set; }
        }
    }
}
