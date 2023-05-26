using System;
using System.Windows.Input;
using BPMobile.Keycloak;

namespace BPMobile.Models
{
    public class MainViewModel
    {
        private readonly KeycloakService _service;

        public ICommand SignOutCommand { get; }

        public MainViewModel(KeycloakService service)
        {
            _service = service;
            SignOutCommand = new Command(async () => await SignOutAsync());
        }

        private async Task SignOutAsync()
        {
            _service.ClearUserInfo();
            // Navigate back to the login page or perform any other action after sign-out.
        }
    }

}

