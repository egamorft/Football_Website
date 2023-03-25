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
            List<Match> list = await _context.Matches.Include(x => x.Statistics)
                                .Include(x => x.Tournament)
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
            DateTime now = DateTime.Now;
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

        // GET: Today tournament
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
            var tournaments = list.GroupBy(m => m.Tournament)
                                    .Select(g => new TournamentDTO
                                    {
                                        TournamentId = g.Key.TournamentId,
                                        Name = g.Key.Name,
                                        Description = g.Key.Description
                                    }).ToList();
            return Ok(tournaments);
        }

        // GET: List specific team upcoming matches
        // https://localhost:5000/api/Match/NextMatches/5
        [HttpGet("NextMatches/{id}")]
        public async Task<IActionResult> GetNextMatches(int id)
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            var now = DateTime.Now;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime > now)
                                                .Where(x => x.Team1Id == id || x.Team2Id == id)
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

        // GET: List specific team matches result
        // https://localhost:5000/api/Match/ResultMatches/Team/5
        [HttpGet("ResultMatches/Team/{id}")]
        public async Task<IActionResult> GetResultMatches(int id)
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            DateTime startDatetime = DateTime.Now.AddHours(-2);
            List<Statistic> list = await _context.Statistics.Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                            .Where(m => m.Matches.Datetime <= startDatetime)
                                                .Where(x => x.Matches.Team1Id == id || x.Matches.Team2Id == id)
                                                    .OrderByDescending(m => m.Matches.Datetime)
                                                        .ToListAsync();
            foreach (Statistic acc in list)
            {
                listDTO.Add(new MatchesDTO
                {
                    MatchesId = acc.Matches.MatchesId,
                    Datetime = acc.Matches.Datetime,
                    TournamentName = acc.Matches.Tournament.Name,
                    Stadium = acc.Matches.Team1.Stadium,
                    Team1Name = acc.Matches.Team1.Name,
                    Team2Name = acc.Matches.Team2.Name,
                    Team1Logo = acc.Matches.Team1.Logo,
                    Team2Logo = acc.Matches.Team2.Logo,
                    Team1ID = acc.Matches.Team1Id,
                    Team2ID = acc.Matches.Team2Id,
                    Team1Goal = acc.Team1Goal,
                    Team2Goal = acc.Team2Goal,
                    StatsID = acc.StatisticId
                });
            }
            return Ok(listDTO);
        }

        // GET: List 3 recent matches result
        // https://localhost:5000/api/Match/MatchesResult
        [HttpGet("MatchesResult")]
        public async Task<IActionResult> GetMatchesResult()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            DateTime startDatetime = DateTime.Now.AddHours(-2);
            List<Statistic> list = await _context.Statistics.Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                            .Where(m => m.Matches.Datetime <= startDatetime)
                                                    .OrderByDescending(m => m.Matches.Datetime)
                                                        .Take(3)
                                                        .ToListAsync();
            foreach (Statistic acc in list)
            {
                listDTO.Add(new MatchesDTO
                {
                    MatchesId = acc.Matches.MatchesId,
                    Datetime = acc.Matches.Datetime,
                    TournamentName = acc.Matches.Tournament.Name,
                    Stadium = acc.Matches.Team1.Stadium,
                    Team1Name = acc.Matches.Team1.Name,
                    Team2Name = acc.Matches.Team2.Name,
                    Team1Logo = acc.Matches.Team1.Logo,
                    Team2Logo = acc.Matches.Team2.Logo,
                    Team1ID = acc.Matches.Team1Id,
                    Team2ID = acc.Matches.Team2Id,
                    Team1Goal = acc.Team1Goal,
                    Team2Goal = acc.Team2Goal,
                    StatsID = acc.StatisticId
                });
            }
            return Ok(listDTO);
        }

        // GET: List all matches result paginate
        // https://localhost:5000/api/Match/RecentResult/1/3
        [HttpGet("RecentResult/{pageNumber}/{pageSize}")]
        public async Task<ActionResult<List<MatchesDTO>>> GetRecentResult(int pageNumber, float pageSize)
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            DateTime startDatetime = DateTime.Now.AddHours(-2);
            var pageCount = Math.Ceiling(_context.Statistics.Include(m => m.Matches).Where(m => m.Matches.Datetime <= startDatetime).Count() / pageSize);
            var matches = await _context.Statistics
                                    .Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                            .Where(m => m.Matches.Datetime <= startDatetime)
                                                    .OrderByDescending(m => m.Matches.Datetime)
                                                        .Skip((pageNumber - 1) * (int)pageSize)
                                                            .Take((int)pageSize).ToListAsync();


            foreach (Statistic acc in matches)
            {
                listDTO.Add(new MatchesDTO
                {
                    MatchesId = acc.Matches.MatchesId,
                    Datetime = acc.Matches.Datetime,
                    TournamentName = acc.Matches.Tournament.Name,
                    Stadium = acc.Matches.Team1.Stadium,
                    Team1Name = acc.Matches.Team1.Name,
                    Team2Name = acc.Matches.Team2.Name,
                    Team1Logo = acc.Matches.Team1.Logo,
                    Team2Logo = acc.Matches.Team2.Logo,
                    Team1ID = acc.Matches.Team1Id,
                    Team2ID = acc.Matches.Team2Id,
                    Team1Goal = acc.Team1Goal,
                    Team2Goal = acc.Team2Goal,
                    StatsID = acc.StatisticId
                });
            }
            var response = new MatchesPaginateResponse
            {
                Matches = listDTO,
                PageNo = pageNumber,
                PageSize = pageSize,
                TotalMatches = (int)(pageCount * pageSize)
            };

            return Ok(response);
        }

        // GET: Get EPL Date Schedule
        // https://localhost:5000/api/Match/EplMatchDate
        [HttpGet("EplMatchDate")]
        public async Task<IActionResult> GetEplMatchDate()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            DateTime now = DateTime.Today;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime.Date > now)
                                                .OrderBy(m => m.Datetime)
                                                    .ToListAsync();
            var groupedMatches = list.GroupBy(m => m.Datetime.Date);

            List<DateTime> result = groupedMatches.Select(g => g.Key).ToList();

            return Ok(result);
        }

        // GET: Get EPL Matches
        // https://localhost:5000/api/Match/EplMatches
        [HttpGet("EplMatches")]
        public async Task<IActionResult> GetEplMatches()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            DateTime today = DateTime.Today;
            List<Match> list = await _context.Matches.Include(x => x.Tournament)
                                    .Include(y => y.Team1)
                                        .Include(z => z.Team2)
                                            .Where(m => m.Datetime.Date > today)
                                                .Where(x => x.TournamentId == 4)
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

    }
}
