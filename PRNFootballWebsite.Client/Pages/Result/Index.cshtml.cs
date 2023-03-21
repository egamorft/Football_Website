using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Result
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ListMatchesUrl = "";
        [BindProperty]
        public MatchesPaginateResponse RecentResults { get; set; }

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ListMatchesUrl = "https://localhost:5000/api/Match/RecentResult/";
        }

        public async Task<IActionResult> OnGet(int p = 1, int s = 4)
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ListMatchesUrl += p + "/" + s;
            //Get recent result
            var response_matches = await httpClient.GetAsync(ListMatchesUrl);
            var content_matches = await response_matches.Content.ReadAsStringAsync();
            RecentResults = JsonSerializer.Deserialize<MatchesPaginateResponse>(content_matches, options);
            //Get recent result

            return Page();

        }
    }
}
