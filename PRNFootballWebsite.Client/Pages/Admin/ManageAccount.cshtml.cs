using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.Client.Pages.Admin
{
    public class ManageAccountModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ListAccountUrl = "";
        [BindProperty]
        public List<AccountDTO> Accounts { get; set; }
        public ManageAccountModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ListAccountUrl = "https://localhost:5000/api/Account/ListAll";
        }

        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string jwt = Request.Cookies["jwt"];
            if (jwt == null)
            {
                return NotFound();
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            //Get list all account
            var response_list = await httpClient.GetAsync(ListAccountUrl);
            var content_list = await response_list.Content.ReadAsStringAsync();
            Accounts = JsonSerializer.Deserialize<List<AccountDTO>>(content_list, options);
            //Get list all account

            return Page();

        }
    }
}
