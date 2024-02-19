using Microsoft.EntityFrameworkCore;
using Stories.API.Data.Configurations;
using Stories.API.Data.Models;
namespace Stories.API.Data
{
    public class MyDataContext(DbContextOptions<MyDataContext> options) : DbContext(options)
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());

        }

    }
}
