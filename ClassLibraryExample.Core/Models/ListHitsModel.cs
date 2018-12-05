using System.Collections.Generic;
using ClassLibraryExample.Core.Pojo;

namespace ClassLibraryExample.Core.Models
{
    public class ListHitsModel
    {
        public int TotalHits { get; set; }
        public IEnumerable<HitModel> Hits { get; set; }
        public int Total { get; set; }
    }
}
