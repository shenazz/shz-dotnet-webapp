using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Data;
using EventRegistrationApp.Models;

namespace EventRegistrationApp.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventContext _context;

        public DetailsModel(EventContext context)
        {
            _context = context;
        }

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
    }
}
