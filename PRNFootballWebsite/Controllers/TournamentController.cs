using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNFootballWebsite.API.Models;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly ProjectPRN231Context _context;

        public TournamentController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet("Tournaments")]
        public async Task<ActionResult> GetTournaments()
        {
            List<Tournament> tournaments = await _context.Tournaments.ToListAsync();
            return Ok(tournaments);
        }
    }
}
