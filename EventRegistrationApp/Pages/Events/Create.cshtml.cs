using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistrationApp.Models;
using EventRegistrationApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace EventRegistrationApp.Pages.Events
{

    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Events == null || Event == null)
            {
                return Page();
            }

            Event.StartTime = DateTime.SpecifyKind(Event.StartTime, DateTimeKind.Utc);
            Event.EndTime = DateTime.SpecifyKind(Event.EndTime, DateTimeKind.Utc);
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
