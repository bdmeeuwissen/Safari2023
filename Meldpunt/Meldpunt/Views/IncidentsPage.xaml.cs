using Meldpunt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Meldpunt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentsPage : ContentPage
    {
        private readonly IncidentsViewModel _incidentsViewModel;
        
        public IncidentsPage()
        {
            InitializeComponent();
            _incidentsViewModel = new IncidentsViewModel();
            BindingContext = _incidentsViewModel;
            
            // Om spacing te geven tussen items in een lijst.
            VoorbeeldList.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 10
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _incidentsViewModel.GetItemsFromDataStore();
        }
    }
}