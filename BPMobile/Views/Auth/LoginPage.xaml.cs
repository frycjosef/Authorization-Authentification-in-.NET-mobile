using BPMobile.ViewModels.Auth;

namespace BPMobile.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginviewmodel)
    {
        InitializeComponent();
        BindingContext = loginviewmodel;
    }
}