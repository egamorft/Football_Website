using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Epl
{
    public class teamsModel : PageModel
    {
        private readonly HttpClient client = null;
        private string AllTeamsList = "";
        [BindProperty]
        public List<TeamDTO> ListTeams { get; set; }
        public teamsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AllTeamsList = "https://localhost:5000/api/Team";
        }
        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            //List all team
            var response_teams = await httpClient.GetAsync(AllTeamsList);
            var content_teams = await response_teams.Content.ReadAsStringAsync();
            ListTeams = JsonSerializer.Deserialize<List<TeamDTO>>(content_teams, options);
            //List all team

            return Page();

        }
    }
}
