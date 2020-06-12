using System.Data.Entity;
using WCFTicketService.Domains;

namespace WCFTicketService.Infrastructure
{
    public class TicketDbContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }

        public TicketDbContext() : base(@"Server=DESKTOP-YT0893\ERADZESQL; Database=MidtermTickets; Trusted_Connection=True")
        {
        }
    }
}