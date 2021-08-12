using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public ICollection<ArticleTag> TagsLink { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleTag> ArticleLink { get; set; }
    }

    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}