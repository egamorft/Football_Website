using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using DataAccess.Models;
using System.Text;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PRNFootballWebsite.Client.Pages.Admin
{
    public class AddNewMatchModel : PageModel
    {
        private readonly HttpClient client = null;
        private string AllTeamsList = "";
        [BindProperty]
        public List<TeamDTO> ListTeams { get; set; }
        [BindProperty]
        public MatchesDTO Matches { get; set; }
        public AddNewMatchModel()
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

        public async Task<IActionResult> OnPostAsync()
        {
            var httpClient = new HttpClient();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string jwt = Request.Cookies["jwt"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var data = JsonConvert.SerializeObject(Matches);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:5000/api/Match/AddNew", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/ManageMatches");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                ModelState.AddModelError(string.Empty, "You have to choose different team");
                //List all team
                var response_teams = await httpClient.GetAsync(AllTeamsList);
                var content_teams = await response_teams.Content.ReadAsStringAsync();
                ListTeams = JsonSerializer.Deserialize<List<TeamDTO>>(content_teams, options);
                //List all team
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                //List all team
                var response_teams = await httpClient.GetAsync(AllTeamsList);
                var content_teams = await response_teams.Content.ReadAsStringAsync();
                ListTeams = JsonSerializer.Deserialize<List<TeamDTO>>(content_teams, options);
                //List all team
                return Page();
            }
        }
    }
}
