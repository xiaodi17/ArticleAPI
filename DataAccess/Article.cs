using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("Id")]
        public virtual Article Article { get; set; }
    }
}