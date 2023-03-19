using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using DataAccess.DTO;
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
        // https://localhost:5000/api/Match
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
                    Team2Name = acc.Team2.Name,
                    Team1Logo = acc.Team1.Logo,
                    Team2Logo = acc.Team2.Logo,
                    Team1ID = acc.Team1Id,
                    Team2ID = acc.Team2Id,
                });
            }
            return Ok(listDTO);
        }

        // GET: First upcoming matches
        // https://localhost:5000/api/Match/FirstUpcomingMatch
        [HttpGet("FirstUpcomingMatch")]
        public async Task<ActionResult> GetFirstUpcomingMatch()
        {
            var now = DateTime.Now;
            var lastestMatch = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .Where(m => m.Datetime > now)
                .OrderBy(m => m.Datetime)
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
                Team2Name = lastestMatch.Team2.Name,
                Team1Logo = lastestMatch.Team1.Logo,
                Team2Logo = lastestMatch.Team2.Logo,
                Team1ID = lastestMatch.Team1Id,
                Team2ID = lastestMatch.Team2Id,
            };
            return Ok(dto);
        }

        // GET: List next 4 upcoming matches
        // https://localhost:5000/api/Match/NextUpcomingMatches
        [HttpGet("NextUpcomingMatches")]
        public async Task<IActionResult> GetUpcomingMatches()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            var now = DateTime.Now;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime > now)
                                                .OrderBy(m => m.Datetime)
                                                    .Skip(1).Take(4)
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
                    Team2Name = acc.Team2.Name,
                    Team1Logo = acc.Team1.Logo,
                    Team2Logo = acc.Team2.Logo,
                    Team1ID = acc.Team1Id,
                    Team2ID = acc.Team2Id,
                });
            }
            return Ok(listDTO);
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
                Team2Name = lastestMatch.Team2.Name,
                Team1Logo = lastestMatch.Team1.Logo,
                Team2Logo = lastestMatch.Team2.Logo,
                Team1ID = lastestMatch.Team1Id,
                Team2ID = lastestMatch.Team2Id,
            };
            return Ok(dto);
        }

        // GET: Today matchup
        // https://localhost:5000/api/Match/TodayMatchUp
        [HttpGet("TodayMatchUp")]
        public async Task<IActionResult> GetTodayMatchUp()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            var today = DateTime.Today;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime.Date == today)
                                                .OrderBy(m => m.Datetime)
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
                    Team2Name = acc.Team2.Name,
                    Team1Logo = acc.Team1.Logo,
                    Team2Logo = acc.Team2.Logo,
                    Team1ID = acc.Team1Id,
                    Team2ID = acc.Team2Id,
                });
            }
            return Ok(listDTO);
        }

        // GET: Today matchup
        // https://localhost:5000/api/Match/TodayTournament
        [HttpGet("TodayTournament")]
        public async Task<IActionResult> GetTodayTournament()
        {
            List<TournamentDTO> listDTO = new List<TournamentDTO>();
            var today = DateTime.Today;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime.Date == today)
                                                .OrderBy(m => m.Datetime)
                                                    .ToListAsync();
            foreach (Match acc in list)
            {
                listDTO.Add(new TournamentDTO
                {
                    TournamentId = acc.Tournament.TournamentId,
                    Name = acc.Tournament.Name,
                    Description = acc.Tournament.Description,
                });
            }
            return Ok(listDTO);
        }
    }
}
