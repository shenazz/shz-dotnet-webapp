using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationApp.Pages.Events;

public class IndexModel : PageModel
{
    private readonly EventContext _context;

    [BindProperty(SupportsGet = true)]
    public string? SearchKey { get; set; }

    public IndexModel(EventContext context)
    {
        _context = context;
    }

    public IList<Event> Event { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrEmpty(SearchKey))
        {
            Event = await _context.Events.Where(@event => @event.Name != null && @event.Name.ToLower().Contains(SearchKey.ToLower())).ToListAsync();
        }
        else
        {
            Event = await _context.Events.ToListAsync();
        }

    }
}

