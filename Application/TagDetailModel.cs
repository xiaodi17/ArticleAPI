using System.Collections.Generic;

namespace Application
{
    public class TagDetailModel
    {
        public string Tag { get; set; }
        public int Count { get; set; }
        public List<int> Articles { get; set; }
        public List<string> RelatedTags { get; set; }
    }
}