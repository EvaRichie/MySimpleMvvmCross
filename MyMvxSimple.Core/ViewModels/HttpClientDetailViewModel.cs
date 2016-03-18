using MvvmCross.Core.ViewModels;
using MyMvxSimple.Core.Services.DataStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.ViewModels
{
    public class HttpClientDetailViewModel : MvxViewModel
    {
        private Item _selecteditem;

        public Item SelectedItem
        {
            get { return _selecteditem; }
            set { _selecteditem = value; RaisePropertyChanged(() => SelectedItem); }
        }

        public void Init(string jsonObj)
        {
            if (!string.IsNullOrEmpty(jsonObj))
                SelectedItem = JsonConvert.DeserializeObject<Item>(jsonObj);
        }
    }
}
