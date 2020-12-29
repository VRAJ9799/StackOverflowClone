using System.Data.Entity;

namespace StackOverflowClone.DomainModels
{
    public class StackOverflowDatabaseDbContext : DbContext
    {
        public StackOverflowDatabaseDbContext() : base("name=StackOverflowDatabase") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
