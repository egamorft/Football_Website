using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRNFootballWebsite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;
        private readonly IConfiguration _configuration;

        public AccountController(ProjectPRN231Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //POST: Login account
        //https://localhost:5000/api/Account/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] AccountDTO account)
        {
            if (account.UserName != null && account.Password != null)
            {
                var acc = await _context.Accounts.FirstOrDefaultAsync(x => x.UserName == account.UserName && x.Password == account.Password);
                if (acc != null)
                {
                    // Create Claim details
                    string role = account?.RoleId.ToString() ?? "2";
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, account?.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, account?.UserName),
                        new Claim(ClaimTypes.Role, role)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: Get account infomation
        //https://localhost:5000/api/Account/Infomation/egamorft
        [Authorize]
        [HttpGet("Infomation/{username}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetInfomation(string username)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserName == username);
            // New DTO To Show data 
            AccountDTO acc = new AccountDTO
            {
                UserName = account.UserName,
                AccountId = account.AccountId,
                CreatedDate = account.CreatedDate,
                FullName = account.FullName,
                Password = account.Password,
                RoleId = account.RoleId,
                StatusId = account.StatusId,
            };
            if (acc == null)
            {
                return NotFound();
            }
            return Ok(acc);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        // https://localhost:5000/api/Account/Register
        public async Task<IActionResult> Register([FromBody] AccountDTO account)
        {
            try
            {
                if (account != null && account.UserName != null && account.Password != null)
                {
                    if (UsernameExists(account.UserName))
                    {
                        return NotFound();
                    }
                    _context.Add<Account>(new Account
                    {
                        UserName = account.UserName,
                        Password = account.Password,
                        CreatedDate = DateTime.Now,
                        FullName = account.FullName,
                    });

                    _context.SaveChanges();
                    return Ok(account);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Fail at running");
            }
        }

        private bool UsernameExists(string username)
        {
            return _context.Accounts.Any(e => e.UserName == username);
        }

    }
}
