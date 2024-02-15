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
        private readonly ApplicationDbContext   _context;

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

        [HttpGet("GetByCommitteeId")]
        public async Task<IActionResult> GetByCommitteeId(byte id)
        {
            var users = await _context.Users
                .Where(u => u.CommitteeId == id && u.Position.ToLower() != "member")
                .OrderByDescending(u => u.Role)
                .Include(c => c.Committee)
                .ToListAsync();

            if ( users == null)
                return NotFound($"there is no committee with this Id");


            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommittee(CommitteeDto dto)
        {
            var committee = new Committee { Name = dto.Name, 
                Description = dto.Description,
                Image = dto.Image};

            await _context.AddAsync(committee);

            _context.SaveChanges();

            return Ok(committee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommittee(byte id, CommitteeDto dto)
        {
            var committee = await _context.Committees.FindAsync(id);

            if (committee == null)
                return NotFound($"there is no committee with this Id");

            committee.Name = dto.Name;
            committee.Description = dto.Description;    
            _context.SaveChanges();

            return Ok(committee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommittee(byte id)
        {
            var committee = await _context.Committees.FindAsync(id);

            if (committee == null)
                return NotFound($"there is no committee with this Id");

            _context.Remove(committee);
            _context.SaveChanges();

            return Ok(committee);
        }

    }
}
