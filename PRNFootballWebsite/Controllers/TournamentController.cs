using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.DTO;
using DataAccess.Models;

namespace PRNFootballWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly ProjectPRN231Context _context;

        public TournamentController(ProjectPRN231Context context)
        {
            _context = context;
        }

        // GET: Tournament list
        // https://localhost:5000/api/Tournament
        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            List<TournamentDTO> listDTO = new List<TournamentDTO>();
            List<Tournament> list = await _context.Tournaments.ToListAsync();
            foreach (Tournament a in list)
            {
                listDTO.Add(new TournamentDTO
                {
                    TournamentId = a.TournamentId,
                    Name = a.Name,
                    Description = a.Description
                });
            }
            return Ok(listDTO);
        }
    }
}
