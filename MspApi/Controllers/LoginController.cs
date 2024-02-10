using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MspApi.Dtos;
using MspApi.Models;

namespace MspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromQuery] LoginDto dto, [FromQuery] int number)
        {
            bool student = false;
            // 1-> crew 2-> admin 3->super
            if (number == 1)
                student = await _context.Crew.AnyAsync(s => s.Gmail == dto.Gmail && s.Password == dto.Password);

            else if (number == 2)
                student = await _context.Admins.AnyAsync(s => s.Gmail == dto.Gmail && s.Password == dto.Password);

            else if (number == 3)
                student = await _context.SuperAdmins.AnyAsync(s => s.Gmail == dto.Gmail && s.Password == dto.Password);

            else
                return NotFound("wrong choice");


            if (student == false)
            {
                return NotFound("Invalid Email or Password !!!");
            }
  
            return Ok(number);
        }
    }

}
