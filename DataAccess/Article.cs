using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Article
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ArticleId { get; set; }
        
        [Column("Title")]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Column("Date")]
        public DateTime Date { get; set; }
        
        [Column("Body")]
        public string Body { get; set; }
        
        public List<ArticleTag> ArticleLink { get; set; }
    }

    public class Tag
    {
        [Column("TagId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TagId { get; set; }
        
        [Column("Name")]
        [StringLength(100)]
        public string Name { get; set; }
        
        public List<ArticleTag> ArticleLink { get; set; }
    }

    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}