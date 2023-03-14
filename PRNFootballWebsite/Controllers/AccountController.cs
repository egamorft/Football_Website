using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNFootballWebsite.API.Models;

namespace PRNFootballWebsite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;

        public AccountController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(new Account
                {
                    UserName = account.UserName,
                    Password = account.Password,
                    FullName = account.FullName,
                    Position = account.Position,
                    CreatedDate = DateTime.Now,
                    GoalNumber = account.GoalNumber,
                    RoleId = account.RoleId,
                    StatusId = account.StatusId,
                    TeamId = account.TeamId
                });
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

    }
}
