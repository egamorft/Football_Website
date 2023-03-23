using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace PRNFootballWebsite.Client.Pages
{
    public class registerModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public registerModel(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        [BindProperty]
        public AccountDTO Account { get; set; }
        public async Task<IActionResult> OnPostAsync(AccountDTO account)
        {
            var client = new HttpClient();
            if(account == null)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return Page();
            }

            var data = JsonConvert.SerializeObject(account);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5000/api/Account/Register", content);
            if (response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "You have successfully register! Back to login page to sign in");
                return Page();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                ModelState.AddModelError(string.Empty, "This user name is existed!! Choose another");
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return Page();
            }

        }
    }
}
