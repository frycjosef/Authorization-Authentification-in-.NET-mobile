using System;
using BPMobile.Keycloak;
using BPMobile.ViewModels;
using Microsoft.Maui.Controls;

namespace BPMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewmodel)
        {
            Shell.SetNavBarIsVisible(this, false);
            InitializeComponent();
            BindingContext = mainViewmodel;
        }
    }
}
