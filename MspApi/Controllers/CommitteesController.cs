using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MspApi.Dtos;
using MspApi.Models;

namespace MspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommitteesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommittees()
        {
            var committees = await _context.Committees.OrderBy(c => c.Name).ToListAsync();
            return Ok(committees);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommittee(CommitteeDto dto)
        {
            var committee = new Committee
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _context.AddAsync(committee);

            _context.SaveChanges();

            return Ok(committee);
        }
    }
}