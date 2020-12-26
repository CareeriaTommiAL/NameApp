using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NameApp.Shared;

namespace NameApp.Client.Pages
{
    public interface INameService
    {
        Task<Name[]> GetNamesAsync();
        Task<List<Name>> GetNameListAsync();
        Task<int> GetCountAsync();
    }
}
