using NotApolloCore.Models;
using Microsoft.EntityFrameworkCore;

namespace NotApolloCore.Data
{
    public class NotApolloContext : DbContext
    {
        public NotApolloContext(DbContextOptions<NotApolloContext> options) : base(options) { }

        public DbSet<ProgramOwners> ProgramOwners { get; set; }
    }
}
