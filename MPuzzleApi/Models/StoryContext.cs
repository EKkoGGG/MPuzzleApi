using Microsoft.EntityFrameworkCore;

namespace MPuzzleApi.Models
{
    public class StoryContext : DbContext
    {
        public StoryContext(DbContextOptions<StoryContext> options)
            : base(options)
        {
        }

        public DbSet<Story> Story { get; set; }
    }
}