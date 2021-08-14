using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Tag> Tag { get; set; }
        
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
            
            modelBuilder.Entity<ArticleTag>()
                .HasOne(x => x.Article)
                .WithMany(x => x.ArticleLink)
                .HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.ArticleLink)
                .HasForeignKey(x => x.TagId);

            base.OnModelCreating(modelBuilder);
           
        }
    }
}