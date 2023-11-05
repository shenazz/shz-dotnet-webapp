using EventRegistrationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationApp.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<EventRegistration> EventRegistrations { get; set; }

    }
}
