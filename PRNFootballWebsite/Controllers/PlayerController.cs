using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ProjectPRN231Context _context;

        public PlayerController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: List specific team's player
        // https://localhost:5000/api/Player/Team/5
        [HttpGet("Team/{id}")]
        public async Task<IActionResult> GetPlayerTeam(int id)
        {
            List<PlayerDTO> listDTO = new List<PlayerDTO>();
            List<Player> list = await _context.Players
                                            .Where(m => m.TeamId == id)
                                                .OrderBy(m => m.PlayerName)
                                                    .ToListAsync();
            foreach (Player acc in list)
            {
                listDTO.Add(new PlayerDTO
                {
                    PlayerId = acc.PlayerId,
                    PlayerName = acc.PlayerName,
                    Dob = acc.Dob,
                    Assist = acc.Assist,
                    Goal = acc.Goal,
                    Height = acc.Height,
                    Img = acc.Img,
                    Nationality = acc.Nationality,
                    Position = acc.Position
                });
            }
            return Ok(listDTO);
        }
    }
}
