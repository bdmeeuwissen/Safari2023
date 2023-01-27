using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Meldpunt.Models;
using Meldpunt.Views;
using Xamarin.Forms;

namespace Meldpunt.ViewModels
{
    public class VoorbeeldViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }

        public ICommand AddCommand { get; }
        public ICommand TapCommand { get; }

        private string _naam;
        public string Naam
        {
            get => _naam;
            set => SetProperty(ref _naam, value);
        }

        private DateTimeOffset _geboortedatum = DateTime.Now;
        public DateTimeOffset Geboortedatum
        {
            get => _geboortedatum;
            set => SetProperty(ref _geboortedatum, value);
        }

        private string _beschrijving;
        public string Beschrijving
        {
            get => _beschrijving;
            set => SetProperty(ref _beschrijving, value);
        }

        private string _telefoonnummer;
        public string Telefoonnummer
        {
            get => _telefoonnummer;
            set => SetProperty(ref _telefoonnummer, value);
        }

        public VoorbeeldViewModel()
        {
            Items = new ObservableCollection<Item>();

            AddCommand = new Command(async ()=> await Add());
            TapCommand = new Command<Item>(async (item) => await Tap(item));
        }

        async Task Add()
        {
            // Check of alle verplichte velden zijn ingevuld. Zo niet toon een alert.
            if (string.IsNullOrEmpty(Naam) || string.IsNullOrEmpty(Beschrijving) || string.IsNullOrEmpty(Telefoonnummer))
            {
                await Shell.Current.DisplayAlert("Uh Oh!", "Niet alle velden zijn ingevuld.", "OK");
                return;
            }

            // Map the gegevens naar een de Item object.
            var item = new Item
            {
                Naam = Naam,
                Geboortedatum = Geboortedatum,
                Beschrijving = Beschrijving,
                Telefoonnummer = Telefoonnummer
            };

            await DataStore.AddItemAsync(item);

            // Wis de gegevens 
            Naam = string.Empty;
            Geboortedatum = DateTimeOffset.Now;
            Beschrijving = string.Empty;
            Telefoonnummer = string.Empty;
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
