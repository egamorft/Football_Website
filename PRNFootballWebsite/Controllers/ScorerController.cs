using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
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
                    IsOwnGoal = acc.IsOwnGoal,
                    PlayerId = acc.Player.PlayerId,
                    TeamId = acc.Player.TeamId,
                });
            }
            return Ok(listDTO);
        }


        // DELETE: https://localhost:5000/api/Scorer/DeleteAll/{stats_id}
        [Authorize]
        [HttpDelete("DeleteAll/{stats_id}")]
        public async Task<IActionResult> DeleteAllByStatsId(int? stats_id)
        {
            if (stats_id == null)
            {
                return BadRequest("stats_id is null.");
            }
            var statsToDelete = await _context.MatchScorers.Where(o => o.StatisticId == stats_id).ToListAsync();
            if (statsToDelete == null || !statsToDelete.Any())
            {
                return NotFound();
            }

            _context.MatchScorers.RemoveRange(statsToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: Add new scorer
        // https://localhost:5000/api/Scorer/AddNew
        [Authorize]
        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew([FromBody] MatchScorerDTO msDTO)
        {
            try
            {
                if (msDTO != null)
                {
                    _context.Add<MatchScorer>(new MatchScorer
                    {
                        StatisticId = msDTO.StatisticId,
                        ScoreMinutes = msDTO.ScoreMinutes,
                        IsOwnGoal = 0,
                        PlayerId = msDTO.PlayerId
                    });

                    _context.SaveChanges();
                    return Ok(msDTO);
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

    }
}
