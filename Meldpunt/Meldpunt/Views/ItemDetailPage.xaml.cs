using System;
using System.Collections.Generic;
using Meldpunt.ViewModels;
using Xamarin.Forms;

namespace Meldpunt.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = new ItemDetailViewModel();
        }
    }
}

