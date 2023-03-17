using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNFootballWebsite.API.DTO;
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

        // GET: List all account
        // https://localhost:5000/api/Account
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            List<AccountDTO> listDTO = new List<AccountDTO>();
            List<Account> list = await _context.Accounts.ToListAsync();
            foreach(Account acc in list)
            {
                listDTO.Add(new AccountDTO
                {
                    AccountId = acc.AccountId,
                    UserName = acc.UserName,
                    FullName = acc.FullName,
                    Password = acc.Password,
                    CreatedDate = acc.CreatedDate,
                    RoleId = acc.RoleId,
                    StatusId = acc.StatusId
                });
            }
            return Ok(listDTO);
        }

        // GET: Get specific account
        // https://localhost:5000/api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

                var dto = new AccountDTO
                {
                    AccountId = account.AccountId,
                    UserName = account.UserName,
                    FullName = account.FullName,
                    Password = account.Password,
                    CreatedDate = account.CreatedDate,
                    RoleId = account.RoleId,
                    StatusId = account.StatusId
                };

            return Ok(dto);
        }

        // POST: Add account
        // https://localhost:5000/api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] AccountDTO accountDTO)
        {
            try
            {
                var account = new Account
                {
                    UserName = accountDTO.UserName,
                    Password = accountDTO.Password,
                    FullName = accountDTO.FullName,
                    CreatedDate = DateTime.Now,
                    RoleId = accountDTO.RoleId,
                    StatusId = accountDTO.StatusId,
                };
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return Ok(account);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }
        //PUT: Edit specific account
        //https://localhost:5000/api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(int id, AccountDTO accountDTO)
        {
            if (id != accountDTO.AccountId)
            {
                return BadRequest();
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            account.UserName = accountDTO.UserName;
            account.FullName = accountDTO.FullName;
            account.Password = accountDTO.Password;
            account.StatusId = accountDTO.StatusId;
            account.RoleId = accountDTO.RoleId;
            // Update any other properties as needed

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(account);
        }

        // Check account exist in db
        private bool MyAccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }

    }
}
