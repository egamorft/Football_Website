using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;

        public StatisticController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: List specific match stats
        // https://localhost:5000/api/Statistic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> GetStatistic(int id)
        {
            var list = await _context.Statistics
                                    .Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                                .FirstOrDefaultAsync(x => x.StatisticId == id);

            if (list == null)
            {
                return NotFound();
            }
            var dto = new StatisticDTO
            {
                StatisticId = list.StatisticId,
                Stadium = list.Matches.Team1.Stadium,
                Datetime = list.Matches.Datetime,
                Team1Corner = list.Team1Corner,
                Team2Corner = list.Team2Corner,
                Team1Goal = list.Team1Goal,
                Team2Goal = list.Team2Goal,
                Team1ID = list.Matches.Team1Id,
                Team2ID = list.Matches.Team2Id,
                Team1Logo = list.Matches.Team1.Logo,
                Team2Logo = list.Matches.Team2.Logo,
                Team1Name = list.Matches.Team1.Name,
                Team2Name = list.Matches.Team2.Name,
                Team1Ontarget = list.Team1Ontarget,
                Team2Ontarget = list.Team2Ontarget,
                Team1Possession = list.Team1Possession,
                Team2Possession = list.Team2Possession,
                Team1Shoot = list.Team1Shoot,
                Team2Shoot = list.Team2Shoot,
                TournamentName = list.Matches.Tournament.Name,
            };

            return Ok(dto);
        }

        // GET: List all match stats
        // https://localhost:5000/api/Statistic/All
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            List<StatisticDTO> listDTO = new List<StatisticDTO>();
            List<Statistic> list = await _context.Statistics
                                    .Include(x => x.Matches)
                                    .ThenInclude(x => x.Team1)
                                        .Include(y => y.Matches)
                                        .ThenInclude(y => y.Team2)
                                            .Include(z => z.Matches)
                                            .ThenInclude(z => z.Tournament)
                                                .ToListAsync();

            if (list == null)
            {
                return NotFound();
            }
            foreach (Statistic acc in list)
            {
                listDTO.Add(new StatisticDTO
                {
                    StatisticId = acc.StatisticId,
                    Stadium = acc.Matches.Team1.Stadium,
                    Datetime = acc.Matches.Datetime,
                    Team1Corner = acc.Team1Corner,
                    Team2Corner = acc.Team2Corner,
                    Team1Goal = acc.Team1Goal,
                    Team2Goal = acc.Team2Goal,
                    Team1ID = acc.Matches.Team1Id,
                    Team2ID = acc.Matches.Team2Id,
                    Team1Logo = acc.Matches.Team1.Logo,
                    Team2Logo = acc.Matches.Team2.Logo,
                    Team1Name = acc.Matches.Team1.Name,
                    Team2Name = acc.Matches.Team2.Name,
                    Team1Ontarget = acc.Team1Ontarget,
                    Team2Ontarget = acc.Team2Ontarget,
                    Team1Possession = acc.Team1Possession,
                    Team2Possession = acc.Team2Possession,
                    Team1Shoot = acc.Team1Shoot,
                    Team2Shoot = acc.Team2Shoot,
                    TournamentName = acc.Matches.Tournament.Name,
                    MatchId = acc.MatchesId,
                });
            }

            return Ok(listDTO);
        }


        // GET: List table EPL
        // https://localhost:5000/api/Statistic/Epl/Table
        [HttpGet("Epl/Table")]
        public async Task<IActionResult> GetEplTable()
        {
            var teams = await _context.Teams.Where(t => t.TournamentId == 4)
            .Select(t => new TableRanking
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Logo = t.Logo,
                GamesPlayed = t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null)) + t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null)),
                Wins = t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal > s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal > s.Team1Goal)))) +
                       t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal < s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal < s.Team1Goal)))),

                Draws = t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal == s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal == s.Team1Goal)))) +
                        t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal == s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal == s.Team1Goal)))),

                Losses = t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal < s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal < s.Team1Goal)))) +
                         t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal > s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal > s.Team1Goal)))),

                GoalsFor = t.MatchTeam1s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team1Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team2Id))).Select(s => t.TeamId == s.Matches.Team1Id ? s.Team1Goal : s.Team2Goal)).Sum() +
                           t.MatchTeam2s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team2Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team1Id))).Select(s => t.TeamId == s.Matches.Team2Id ? s.Team2Goal : s.Team1Goal)).Sum(),

                GoalsAgainst = t.MatchTeam1s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team1Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team2Id))).Select(s => t.TeamId == s.Matches.Team1Id ? s.Team2Goal : s.Team1Goal)).Sum() +
                               t.MatchTeam2s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team2Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team1Id))).Select(s => t.TeamId == s.Matches.Team2Id ? s.Team1Goal : s.Team2Goal)).Sum(),

                GoalDifference = t.MatchTeam1s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team1Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team2Id))).Select(s => t.TeamId == s.Matches.Team1Id ? s.Team1Goal - s.Team2Goal : s.Team2Goal - s.Team1Goal)).Sum() +
                                 t.MatchTeam2s.SelectMany(m => m.Statistics.Where(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && t.TeamId == s.Matches.Team2Id) || (s.Matches.Team2Id == t.TeamId && t.TeamId == s.Matches.Team1Id))).Select(s => t.TeamId == s.Matches.Team2Id ? s.Team2Goal - s.Team1Goal : s.Team1Goal - s.Team2Goal)).Sum(),
                Points = t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal > s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal > s.Team1Goal)))) * 3 +
                         t.MatchTeam1s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal == s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal == s.Team1Goal)))) +
                         t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal < s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal < s.Team1Goal)))) * 3 +
                         t.MatchTeam2s.Count(m => m.Statistics.Any(s => s.Team1Goal != null && s.Team2Goal != null && ((s.Matches.Team1Id == t.TeamId && s.Team1Goal == s.Team2Goal) || (s.Matches.Team2Id == t.TeamId && s.Team2Goal == s.Team1Goal))))
            })
            .OrderByDescending(t => t.Points)
            .ThenByDescending(t => t.GoalDifference)
            .ThenByDescending(t => t.GoalsFor)
            .ToListAsync();

            return Ok(teams);
        }
    }
}
