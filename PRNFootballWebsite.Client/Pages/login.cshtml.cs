using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace PRNFootballWebsite.Client.Pages
{

    public class loginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public loginModel(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        [BindProperty]
        public AccountDTO Account { get; set; }
        public string JwtToken { get; set; }
        public AccountDTO AccountInfo { get; set; }
        public async Task<IActionResult> OnPostAsync(AccountDTO account)
        {
            var client = new HttpClient();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var response = await client.PostAsJsonAsync("https://localhost:5000/api/Account/login", account);

            JwtToken = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                var response_info = await client.GetAsync("https://localhost:5000/api/Account/Infomation/" + account.UserName);
                var content_info = await response_info.Content.ReadAsStringAsync();
                // Store the JWT token in a cookie or in local storage, for example:
                AccountInfo = JsonSerializer.Deserialize<AccountDTO>(content_info, options);
                Response.Cookies.Append("jwt", JwtToken);
                if (AccountInfo.StatusId == 2)
                {
                    ModelState.AddModelError(string.Empty, "Your account is deactive");
                    return Page();
                }
                if(AccountInfo.RoleId == 1)
                {
                    //Admin
                    HttpContext.Session.SetString("admin", JsonSerializer.Serialize(AccountInfo));
                    return RedirectToPage("/Admin");
                }
                HttpContext.Session.SetString("user", JsonSerializer.Serialize(AccountInfo));
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
    }
}
