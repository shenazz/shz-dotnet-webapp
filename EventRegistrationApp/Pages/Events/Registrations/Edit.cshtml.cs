using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace EventRegistrationApp.Pages.Events.Registrations
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly EventContext _context;

        public EditModel(EventContext context)
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
            EventRegistration = eventregistration;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRegistrationExists(EventRegistration.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Events/Registrations/List", new { eventId = EventRegistration.EventId });

        }

        private bool EventRegistrationExists(long id)
        {
            return (_context.EventRegistrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
