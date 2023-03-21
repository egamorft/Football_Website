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
    }
}
