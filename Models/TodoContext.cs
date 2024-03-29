using Microsoft.EntityFrameworkCore;

namespace EmissionApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<Emission> Emissions { get; set; }
    }
}