using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EventRegistrationApp.Pages.Events
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
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }
            else
            {
                Event = @event;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FindAsync(id);

            if (@event != null)
            {
                Event = @event;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
