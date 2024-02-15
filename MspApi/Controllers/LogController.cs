using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MspApi.Dtos;
using MspApi.Models;

namespace MspApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/login")]
        public async Task<IActionResult> Login([FromForm] string mail, [FromForm] string pass)
        {
            var user = _context.Users.FirstOrDefaultAsync(u=>u.Gmail == mail && u.Password == pass);

            if (user == null) 
            { 
                BadRequest("Gmail or Password not correct");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register([FromForm] UserDto dto)
        {
            if(dto == null) { BadRequest(); }

            if(!ModelState.IsValid) { return BadRequest(); }

            //another user has the same mail that not allow
            var usermail = _context.Users.FirstOrDefaultAsync(u => u.Gmail == dto.Gmail);
            if (usermail!= null) {  return BadRequest("invalid mail try agine :)"); }

            //another user has the same StudentId that not allow
            var userid = _context.Users.FirstOrDefaultAsync(u => u.StudentId == dto.StudentId);
            if (userid != null) { return BadRequest("invalid StudentId try agine :)"); }

          
            var user = new User
            {
                StudentId= dto.StudentId,
                Name=dto.Name,
                Gmail=dto.Gmail,
                Password=dto.Password,
                Role="User",
                Position="Member",
                Waiting="Yes",
                Moblie=dto.Moblie,
                Level=dto.Level,
                Rank=0,
                URLPhoto= "https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg",
                URL_QR= "https://drive.google.com/file/d/1YXexNhlPQDdbf9pLLWkzCs4hKUdaxLuh/view?usp=sharing",
                CommitteeId =dto.CommitteeId,

            };

            return Ok(user); 
        }


    }

}
