using BPMobile.ViewModels;

namespace BPMobile;

public partial class AccessDeniedPage : ContentPage
{
    public AccessDeniedPage(AccessDeniedViewModel accessDeniedViewModel)
    {
        Shell.SetNavBarIsVisible(this, false);
        InitializeComponent();
        BindingContext = accessDeniedViewModel;
    }
}