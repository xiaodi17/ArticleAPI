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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ArticleTag>() 
                .HasKey(x => new {x.ArticleId, x.TagId});
            
            // modelBuilder.Entity<ArticleTag>() 
            //     .HasOne(pt => pt.Article)
            //     .WithMany(p => p.TagsLink)
            //     .HasForeignKey(pt => pt.ArticleId);
            //
            // modelBuilder.Entity<ArticleTag>() 
            //     .HasOne(pt => pt.Tag) 
            //     .WithMany(t => t.ArticleLink)
            //     .HasForeignKey(pt => pt.TagId);
        }
    }
}