using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;

        public TeamController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: List all teams
        // https://localhost:5000/api/Team
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            List<TeamDTO> listDTO = new List<TeamDTO>();
            List<Team> list = await _context.Teams.Include(x => x.Tournament).OrderBy(x => x.Name).Where(x => x.TournamentId == 4).ToListAsync();
            foreach (Team acc in list)
            {
                listDTO.Add(new TeamDTO
                {
                    TeamId = acc.TeamId,
                    Name = acc.Name,
                    Stadium = acc.Stadium,
                    Logo = acc.Logo,
                    Location = acc.Location,
                    Site = acc.Site,
                    TournamentName = acc.Tournament.Name,
                });
            }
            return Ok(listDTO);
        }

        // GET: List specific team
        // https://localhost:5000/api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> GetTeam(int id)
        {
            var list = await _context.Teams.Include(x => x.Tournament).FirstOrDefaultAsync(x => x.TeamId == id);

            if(list == null)
            {
                return NotFound();
            }
            var dto = new TeamDTO
            {
                TeamId = list.TeamId,
                Name = list.Name,
                Stadium = list.Stadium,
                Logo = list.Logo,
                Location = list.Location,
                Site = list.Site,
                TournamentName = list.Tournament.Name,
            };

            return Ok(dto);
        }
    }
}
