using Microsoft.EntityFrameworkCore;

namespace MinimalAPI
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
