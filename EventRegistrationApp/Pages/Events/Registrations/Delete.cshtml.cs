using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace EventRegistrationApp.Pages.Events.Registrations
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly EventContext _context;

        public DeleteModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventRegistration EventRegistration { get; set; } = default!;

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long eventId, long id)
        {

            var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == eventId);
            if (@event == null)
            {
                return NotFound();
            }
            else
            {
                Event = @event;
            }

            var eventregistration = await _context.EventRegistrations.FirstOrDefaultAsync(m => m.Id == id);

            if (eventregistration == null)
            {
                return NotFound();
            }
            else
            {
                EventRegistration = eventregistration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.EventRegistrations == null)
            {
                return NotFound();
            }
            var eventregistration = await _context.EventRegistrations.FindAsync(id);

            if (eventregistration != null)
            {
                EventRegistration = eventregistration;
                _context.EventRegistrations.Remove(EventRegistration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Events/Registrations/List", new { eventId = EventRegistration.EventId });
        }
    }
}
