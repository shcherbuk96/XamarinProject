using ClassLibraryExample.Core.Pojo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibraryExample.Core.Service
{
    public interface ILoadDataService
    {
        Task<IEnumerable<HitModel>> GetDataAsync(string url);
    }
}
