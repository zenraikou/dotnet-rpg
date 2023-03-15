namespace dotnet_rpg.Data
{
    public class RPGContext : DbContext
    {
        public RPGContext(DbContextOptions<RPGContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters => Set<Character>();
    }
}