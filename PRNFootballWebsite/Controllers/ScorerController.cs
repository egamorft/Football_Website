using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScorerController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;

        public ScorerController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: List specific match scorer
        // https://localhost:5000/api/Scorer/{5}
        [HttpGet("{statistic_id}")]
        public async Task<ActionResult<List<MatchScorerDTO>>> GetScorer(int statistic_id)
        {
            List<MatchScorerDTO> listDTO = new List<MatchScorerDTO>();
            List<MatchScorer> list = await _context.MatchScorers.Include(s => s.Player)
                                                .ThenInclude(s => s.Team)
                                                    .Where(s => s.StatisticId == statistic_id)
                                                        .OrderBy(s => s.ScoreMinutes)
                                                            .ToListAsync();
            foreach (MatchScorer acc in list)
            {
                listDTO.Add(new MatchScorerDTO
                {
                    StatisticId = acc.StatisticId,
                    PlayerName = acc.Player.PlayerName,
                    TeamName = acc.Player.Team.Name,
                    ScoreMinutes = acc.ScoreMinutes,
                    IsOwnGoal = acc.IsOwnGoal
                });
            }
            return Ok(listDTO);
        }
    }
}
