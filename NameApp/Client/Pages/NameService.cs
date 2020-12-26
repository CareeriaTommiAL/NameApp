using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using NameApp.Shared;

namespace NameApp.Client.Pages
{
    public class NameService : INameService
    {
        private readonly HttpClient Http;
        public NameService(HttpClient httpClient)
        {
            Http = httpClient;
        }

        public async Task<Name[]> GetNamesAsync()
        {
            return await Http.GetFromJsonAsync<Name[]>("api/Names");
        }

        public async Task<List<Name>> GetNameListAsync()
        {
            return await Http.GetFromJsonAsync<List<Name>>("api/Names");
        }

        public async Task<int> GetCountAsync()
        {
            return await Http.GetFromJsonAsync<int>("api/Names/countnames");
        }
    }
}
