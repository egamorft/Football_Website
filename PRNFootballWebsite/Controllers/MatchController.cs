using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using DataAccess.DTO;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.SignalR;

namespace PRNFootballWebsite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {

        private readonly IHubContext<Hub> _hub;
        private readonly ProjectPRN231Context _context;

        public MatchController(IHubContext<Hub> hub, ProjectPRN231Context context)
        {
            _hub = hub;
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

        // GET: List all matches paging filter
        // https://localhost:5000/api/Match/Paging/{pageNumber}/{pageSize}
        [HttpGet("Paging/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetMatchesPaging(int pageNumber, float pageSize, string? txtSearch, string? txtFilter)
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            var pageCount = 0;
            List<Match> list = new List<Match>();
            if (txtFilter != null && txtFilter != "")
            {
                if(txtSearch == null || txtSearch == "")
                {
                    switch (txtFilter)
                    {
                        case "finished":
                            pageCount = (int)Math.Ceiling(_context.Matches.Where(s => DateTime.Now > s.Datetime.AddHours(2)).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                                .Where(s => DateTime.Now > s.Datetime.AddHours(2))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                        case "notStarted":
                            pageCount = (int)Math.Ceiling(_context.Matches.Where(s => DateTime.Now < s.Datetime.AddMinutes(-30)).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                                .Where(s => DateTime.Now < s.Datetime.AddMinutes(-30))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                        case "happening":
                            pageCount = (int)Math.Ceiling(_context.Matches.Where(s => s.Datetime.AddHours(2) > DateTime.Now && DateTime.Now > s.Datetime.AddMinutes(-20)).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                            .Where(s => s.Datetime.AddHours(2) > DateTime.Now && DateTime.Now > s.Datetime.AddMinutes(-20))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                    }
                }
                else
                {
                    switch (txtFilter)
                    {
                        case "finished":
                            pageCount = (int)Math.Ceiling(_context.Matches.Include(y => y.Team1).Include(z => z.Team2).Where(s => DateTime.Now > s.Datetime.AddHours(2)).Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower())).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                                .Where(s => DateTime.Now > s.Datetime.AddHours(2))
                                                                .Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower()))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                        case "notStarted":
                            pageCount = (int)Math.Ceiling(_context.Matches.Include(y => y.Team1).Include(z => z.Team2).Where(s => DateTime.Now < s.Datetime.AddMinutes(-30)).Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower())).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                                .Where(s => DateTime.Now < s.Datetime.AddMinutes(-30))
                                                                .Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower()))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                        case "happening":
                            pageCount = (int)Math.Ceiling(_context.Matches.Include(y => y.Team1).Include(z => z.Team2).Where(s => s.Datetime.AddHours(2) > DateTime.Now && DateTime.Now > s.Datetime.AddMinutes(-20)).Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower())).Count() / pageSize);
                            list = await _context.Matches.Include(x => x.Statistics)
                                                .Include(x => x.Tournament)
                                                    .Include(y => y.Team1)
                                                        .Include(z => z.Team2)
                                                            .OrderByDescending(o => o.Datetime)
                                                                .Where(s => s.Datetime.AddHours(2) > DateTime.Now && DateTime.Now > s.Datetime.AddMinutes(-20))
                                                                .Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower()))
                                                                .Skip((pageNumber - 1) * (int)pageSize)
                                                                    .Take((int)pageSize).ToListAsync();
                            break;
                    }
                }
            }
            else
            {
                if(txtSearch == null || txtSearch == "")
                {
                    pageCount = (int)Math.Ceiling(_context.Matches.Count() / pageSize);
                    list = await _context.Matches.Include(x => x.Statistics)
                                        .Include(x => x.Tournament)
                                            .Include(y => y.Team1)
                                                .Include(z => z.Team2)
                                                    .OrderByDescending(o => o.Datetime)
                                                        .Skip((pageNumber - 1) * (int)pageSize)
                                                            .Take((int)pageSize).ToListAsync();
                }
                else
                {
                    pageCount = (int)Math.Ceiling(_context.Matches.Include(y => y.Team1).Include(z => z.Team2).Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower())).Count() / pageSize);
                    list = await _context.Matches.Include(x => x.Statistics)
                                        .Include(x => x.Tournament)
                                            .Include(y => y.Team1)
                                                .Include(z => z.Team2)
                                                    .OrderByDescending(o => o.Datetime)
                                                    .Where(t => t.Team1.Name.ToLower().Contains(txtSearch.ToLower()) || t.Team2.Name.ToLower().Contains(txtSearch.ToLower()))
                                                        .Skip((pageNumber - 1) * (int)pageSize)
                                                            .Take((int)pageSize).ToListAsync();
                }
            }
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

        // POST: Add new match
        // https://localhost:5000/api/Match/AddNew
        [Authorize]
        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew([FromBody] MatchesDTO match)
        {
            try
            {
                if (match != null && match.Team1ID != null && match.Team2ID != null)
                {
                    if(match.Team1ID != match.Team2ID)
                    {
                        _context.Add<Match>(new Match
                        {
                            Datetime = match.Datetime,
                            Team1Id = match.Team1ID,
                            Team2Id = match.Team2ID,
                            TournamentId = 4,
                        });

                        _context.SaveChanges();
                        return Ok(match);
                    }
                    else
                    {
                        return NotFound("TeamId must be different");
                    }
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

        // PUT: Edit matches
        // https://localhost:5000/api/Match/Edit/{id}
        [Authorize]
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> GetEdit(int id, [FromBody] MatchesDTO matches)
        {
            // Update the model with the given ID asynchronously
            var match = await _context.Matches.FirstOrDefaultAsync(x => x.MatchesId == id);
            if (match == null)
            {
                return BadRequest("Match not found");
            }
            match.Team1Id = matches.Team1ID;
            match.Team2Id = matches.Team2ID;
            match.Datetime = matches.Datetime;

            await _context.SaveChangesAsync();

            return Ok(match);
        }

        // GET: Get Matches Happening
        // https://localhost:5000/api/Match/Happening
        [HttpGet("Happening")]
        public async Task<IActionResult> GetHappening()
        {
            List<MatchesDTO> listDTO = new List<MatchesDTO>();
            var matches = await _context.Statistics
                                    .Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                                .Where(m => m.Matches.Datetime.AddHours(2) > DateTime.Now 
                                                    && DateTime.Now > m.Matches.Datetime.AddMinutes(-20)).ToListAsync();
            foreach (Statistic acc in matches)
            {
                listDTO.Add(new MatchesDTO
                {
                    MatchesId = acc.MatchesId,
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
                    Team2Goal = acc.Team2Goal
                });
            }
            return Ok(listDTO);
        }

        // PUT: Edit matches happening
        // https://localhost:5000/api/Match/Happening/Edit
        //[Authorize]
        [HttpPut("Happening/Edit")]
        public async Task<IActionResult> GetEditHappening(MatchesDTO matches)
        {
            // Update the model with the given ID asynchronously
            if(matches == null || matches.MatchesId == null)
            {
                return BadRequest("No data found");
            }
            var match = await _context.Statistics
                                    .Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                                .Where(m => m.Matches.Datetime.AddHours(2) > DateTime.Now
                                                    && DateTime.Now > m.Matches.Datetime.AddMinutes(-20))
                                                        .FirstOrDefaultAsync(x => x.MatchesId == matches.MatchesId);
            if (match == null)
            {
                return BadRequest("Match not found");
            }
            else
            {
                if (matches.Team1ID == match.Matches.Team1Id)
                {
                    match.Team1Goal = (match.Team1Goal != null ? match.Team1Goal : 0) + 1;
                }

                if (matches.Team2ID == match.Matches.Team2Id)
                {
                    match.Team2Goal = (match.Team2Goal != null ? match.Team2Goal : 0) + 1;
                }
            }

            await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("RefreshMatchCentre");

            return Ok();
        }

    }
}
