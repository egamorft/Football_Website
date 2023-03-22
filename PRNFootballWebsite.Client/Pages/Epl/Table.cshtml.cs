using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Epl
{
    public class TableModel : PageModel
    {
        private readonly HttpClient client = null;
        private string TableUrl = "";
        [BindProperty]
        public List<TableRanking> ListTeamTable { get; set; }
        public TableModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TableUrl = "https://localhost:5000/api/Statistic/Epl/Table";
        }

        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            //List table team
            var response_table = await httpClient.GetAsync(TableUrl);
            var content_table = await response_table.Content.ReadAsStringAsync();
            ListTeamTable = JsonSerializer.Deserialize<List<TableRanking>>(content_table, options);
            //List table team

            return Page();

        }
    }
}
