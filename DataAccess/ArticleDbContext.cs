using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}