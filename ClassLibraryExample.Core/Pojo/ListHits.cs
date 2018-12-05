using System.Collections.Generic;

namespace ClassLibraryExample.Core.Pojo
{
    public class ListHits
    {
        public int TotalHits { get; set; }
        public IEnumerable<Hit> Hits { get; set; }
        public int Total { get; set; }
    }
}
