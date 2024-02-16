using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MspApi.Models;

namespace MspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EventController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await context.Events.ToListAsync();

            if (events == null || events.Count == 0)
                return NotFound($"No Events");

            return Ok(events);
        }

        [HttpGet("IdOrName", Name = "GetOneEventRoute")]
        public async Task<IActionResult> GetEventByIDorName(string IdOrName)
        {
            Event eventt = null;
            if (int.TryParse(IdOrName, out int id))
                eventt = await context.Events.FindAsync(id);
            else
                eventt = await context.Events.FirstOrDefaultAsync(d => d.Name == IdOrName.ToLower());

            return eventt != null ? Ok(eventt) : NotFound($"No Event has this Name or ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event eventt)
        {
            if (ModelState.IsValid)
            {
                eventt.Name = eventt.Name.ToLower();
                await context.Events.AddAsync(eventt);
                context.SaveChanges();
                string url = Url.Link("GetOneEventRoute", new { id = eventt.Id });
                return Created(url, eventt);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventByIDorName(string idOrName, Event eventt)
        {
            Event OldEvent = null;

            if (int.TryParse(idOrName, out int id))
                OldEvent = await context.Events.FindAsync(id);
            else
                OldEvent = await context.Events.FirstOrDefaultAsync(d => d.Name == idOrName.ToLower());

            if (OldEvent != null)
            {
                OldEvent.Name = eventt.Name.ToLower();
                OldEvent.Description = eventt.Description;
                OldEvent.Date = eventt.Date;
                OldEvent.DeadTime = eventt.DeadTime;
                OldEvent.FormLink = eventt.FormLink;
                OldEvent.URLPhoto = eventt.URLPhoto;
                OldEvent.Videos = eventt.Videos;
                await context.SaveChangesAsync();

                return Ok(OldEvent);
            }

            return BadRequest("ID or Name Not Valid");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEventByIdorName(string IdOrName)
        {
            Event eventToDelete = null;

            if (int.TryParse(IdOrName, out int id))
                eventToDelete = await context.Events.FindAsync(id);
            else
                eventToDelete = await context.Events.FirstOrDefaultAsync(d => d.Name == IdOrName.ToLower());

            if (eventToDelete == null)
                return NotFound($"No Event has this Name or ID");

            context.Events.Remove(eventToDelete);
            await context.SaveChangesAsync();

            return Ok($"{eventToDelete.Name} event was deleted sucessfuly.");
        }
    }
}