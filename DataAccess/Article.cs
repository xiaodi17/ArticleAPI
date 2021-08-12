using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
    }
}