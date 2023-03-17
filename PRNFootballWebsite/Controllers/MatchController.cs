using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNFootballWebsite.API.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using PRNFootballWebsite.API.DTO;
using System.Security.Principal;

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

        // GET: List all matches
        // https://localhost:5000/api/Matches
        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            List<Match> list = await _context.Matches.Include(x =>x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .OrderByDescending(o => o.Datetime)
                                                .ToListAsync();
            foreach (Match acc in list)
            {
                listDTO.Add(new MatchesDTO
                {
                    MatchesId = acc.MatchesId,
                    Datetime = acc.Datetime,
                    TournamentName = acc.Tournament.Name,
                    Stadium = acc.Team1.Stadium,
                    Team1Name = acc.Team1.Name,
                    Team2Name = acc.Team2.Name
                });
            }
            return Ok(listDTO);
        }

        // GET: List upcoming matches
        // https://localhost:5000/api/UpcomingMatch
        [HttpGet("UpcomingMatch")]
        public async Task<ActionResult> GetUpcomingMatch()
        {
            var lastestMatch = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .OrderByDescending(m => m.Datetime)
                .FirstOrDefaultAsync();

            if (lastestMatch == null)
            {
                return NotFound();
            }
            var dto = new MatchesDTO
            {
                MatchesId = lastestMatch.MatchesId,
                Datetime = lastestMatch.Datetime,
                TournamentName = lastestMatch.Tournament.Name,
                Stadium = lastestMatch.Team1.Stadium,
                Team1Name = lastestMatch.Team1.Name,
                Team2Name = lastestMatch.Team2.Name
            };
            return Ok(dto);
        }

        // GET: Get specific match
        // https://localhost:5000/api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchesDTO>> GetMatch(int id)
        {
            var lastestMatch = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .FirstOrDefaultAsync(x => x.MatchesId == id);

            if (lastestMatch == null)
            {
                return NotFound();
            }
            var dto = new MatchesDTO
            {
                MatchesId = lastestMatch.MatchesId,
                Datetime = lastestMatch.Datetime,
                TournamentName = lastestMatch.Tournament.Name,
                Stadium = lastestMatch.Team1.Stadium,
                Team1Name = lastestMatch.Team1.Name,
                Team2Name = lastestMatch.Team2.Name
            };
            return Ok(dto);
        }

    }
}
