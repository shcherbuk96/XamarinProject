﻿using ClassLibraryExample.Core.Pojo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibraryExample.Core.Service
{
    public interface ILoadData
    {
        Task<IEnumerable<Hit>> GetDataAsync(string message);
    }
}