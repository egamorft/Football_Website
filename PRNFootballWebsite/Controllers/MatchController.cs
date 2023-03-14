using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNFootballWebsite.API.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRNFootballWebsite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {

        private readonly ProjectPRN231Context _context;

        public MatchController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet("Matches")]
        public async Task<ActionResult> GetMatches()
        {
            List<Match> matches = await _context.Matches.OrderByDescending(o => o.Datetime).ToListAsync();
            return Ok(matches);
        }

        // GET: api/UpcomingMatch
        [HttpGet("UpcomingMatch")]
        public async Task<ActionResult> GetUpcomingMatch()
        {
            var lastestMatch = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .OrderByDescending(m => m.Datetime).Select(m => new
                {
                    Matches_ID = m.MatchesId,
                    Datetime = m.Datetime,
                    Stadium = m.Team1.Stadium,
                    Tournament_Name = m.Tournament.Name,
                    Team1_Name = m.Team1.Name,
                    Team2_Name = m.Team2.Name,
                })
                .FirstOrDefaultAsync();

            if (lastestMatch == null)
            {
                return NotFound();
            }
            return Ok(lastestMatch);
        }

    }
}
