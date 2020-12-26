using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NameApp.Shared;
using Microsoft.AspNetCore.Components;

namespace NameApp.Client.Pages
{
    partial class NameList
    {
        [Inject]
        private INameService NameService { get; set; }

        private Name[] names;
        private List<Name> nameList;
        private int nameCount;
        private List<Name> filteredNameList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            names = await NameService.GetNamesAsync();
            nameList = await NameService.GetNameListAsync();
            nameCount = await NameService.GetCountAsync();
        }

        private void OnNameSearchTextChanged(ChangeEventArgs changeEventArgs)
        {
            string searchText = changeEventArgs.Value.ToString();
            filteredNameList = nameList.Where(n => n.Nimi.ToLower().Contains(searchText.Trim().ToLower())).ToList();
        }
    }
}
