using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationApp.Pages.Events.Registrations
{
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }


        [BindProperty]
        public EventRegistration EventRegistration { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(long eventId)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == eventId);
            if (@event == null)
            {
                return NotFound();
            }

            EventRegistration = new EventRegistration
            {
                EventId = eventId
            };

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.EventRegistrations == null || EventRegistration == null)
            {
                return Page();
            }

            _context.EventRegistrations.Add(EventRegistration);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Events/Details", new { id = EventRegistration.EventId });
        }
    }
}
