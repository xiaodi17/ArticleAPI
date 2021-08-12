using System.Collections.Generic;

namespace Application
{
    public class ArticleCreateModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
    }
}