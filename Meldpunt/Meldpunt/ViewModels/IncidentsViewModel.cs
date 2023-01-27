using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Meldpunt.Models;
using Meldpunt.Views;
using Xamarin.Forms;

namespace Meldpunt.ViewModels
{
    public class IncidentsViewModel : BaseViewModel
    {
        private List<Item> _items;

        public IncidentsViewModel()
        {
            TapCommand = new Command<Item>(async (item) => await Tap(item));
        }

        public ICommand TapCommand { get; }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }

        public void GetItemsFromDataStore()
        {
            Items = DataStore.GetItemsAsync().Result.ToList();
        }
        
        async Task Tap(Item item)
        {
            // The System.Text.Json library does not support deserializing DateTimeOffset properties by default. 
            var options = new JsonSerializerOptions
            {
                Converters = { new DateTimeOffsetConverter() }
            };

            var jsonStr = JsonSerializer.Serialize(item, options);
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?Param={jsonStr}");
        }
    }
}