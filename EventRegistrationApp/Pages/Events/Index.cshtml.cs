using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;

namespace EventRegistrationApp.Pages.Events;

public class IndexModel : PageModel
{
    private readonly EventContext _context;

    public IndexModel(EventContext context)
    {
        _context = context;
    }

    public IList<Event> Event { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Events != null)
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}

