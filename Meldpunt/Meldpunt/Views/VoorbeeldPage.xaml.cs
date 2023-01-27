using System;
using System.Collections.Generic;
using Meldpunt.ViewModels;
using Xamarin.Forms;

namespace Meldpunt.Views
{
    public partial class VoorbeeldPage : ContentPage
    {
        public VoorbeeldPage()
        {
            InitializeComponent();

            BindingContext = new VoorbeeldViewModel();
        }
    }
}

