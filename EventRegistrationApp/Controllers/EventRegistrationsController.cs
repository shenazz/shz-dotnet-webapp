using EventRegistrationApp.Data;
using EventRegistrationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EventApi.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationsController : ControllerBase
    {
        private readonly EventContext _context;

        public EventRegistrationsController(EventContext context)
        {
            _context = context;
        }

        // GET: api/EventRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRegistration>>> GetEventRegistrations()
        {
            if (_context.EventRegistrations == null)
            {
                return NotFound();
            }
            return await _context.EventRegistrations.ToListAsync();
        }

        // GET: api/EventRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventRegistration>> GetEventRegistration(long id)
        {
            if (_context.EventRegistrations == null)
            {
                return NotFound();
            }
            var eventRegistration = await _context.EventRegistrations.FindAsync(id);

            if (eventRegistration == null)
            {
                return NotFound();
            }

            return eventRegistration;
        }

        // PUT: api/EventRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventRegistration(long id, EventRegistration eventRegistration)
        {
            if (id != eventRegistration.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventRegistration>> PostEventRegistration(EventRegistration eventRegistration)
        {
            if (_context.EventRegistrations == null)
            {
                return Problem("Entity set 'EventContext.EventRegistrations'  is null.");
            }

            _context.EventRegistrations.Add(eventRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventRegistration), new { id = eventRegistration.Id }, eventRegistration);
        }

        // DELETE: api/EventRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventRegistration(long id)
        {
            if (_context.EventRegistrations == null)
            {
                return NotFound();
            }

            var eventRegistration = await _context.EventRegistrations.FindAsync(id);
            if (eventRegistration == null)
            {
                return NotFound();
            }

            _context.EventRegistrations.Remove(eventRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventRegistrationExists(long id)
        {
            return (_context.EventRegistrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
