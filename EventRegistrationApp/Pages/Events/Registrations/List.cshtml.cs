using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationApp.Pages.Events;

[Authorize]
public class ListModel : PageModel
{
    private readonly EventContext _context;

    public ListModel(EventContext context)
    {
        _context = context;
    }

    public IList<EventRegistration> EventRegistration { get; set; } = default!;

    public Event Event { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(long eventId)
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

        if (_context.Events != null)
        {
            EventRegistration = await _context.EventRegistrations.Where(er => er.EventId == @event.Id).ToListAsync();
        }

        return Page();
    }
}

