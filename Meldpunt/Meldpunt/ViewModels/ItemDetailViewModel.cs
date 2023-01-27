using System.Text.Json;
using Meldpunt.Models;
using Xamarin.Forms;

namespace Meldpunt.ViewModels
{
    [QueryProperty(nameof(Param), nameof(Param))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public string Param
        {
            set
            {
                LoadItem(value);
            }
        }

        private Item _item;
        public Item Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        private void LoadItem(string value)
        {
            // The System.Text.Json library does not support deserializing DateTimeOffset properties by default. 
            var options = new JsonSerializerOptions
            {
                Converters = { new DateTimeOffsetConverter() }
            };

            var item = JsonSerializer.Deserialize<Item>(value, options);
            Item = item;
        }
    }
}

