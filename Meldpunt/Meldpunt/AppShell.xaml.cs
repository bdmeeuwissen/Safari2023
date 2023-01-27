using System;
using System.Collections.Generic;
using Meldpunt.ViewModels;
using Meldpunt.Views;
using Xamarin.Forms;

namespace Meldpunt
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}

