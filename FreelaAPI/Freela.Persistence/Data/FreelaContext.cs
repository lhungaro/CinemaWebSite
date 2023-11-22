using Freela.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelaAPI.Data
{
    public class FreelaContext: DbContext
    {
        public FreelaContext(DbContextOptions<FreelaContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

    }
}
