using System;
using IdentityModel.OidcClient;
using BPMobile.Keycloak;
using Microsoft.Toolkit.Mvvm.Input;
using IdentityModel.Client;

namespace BPMobile.ViewModels.Auth
{
	public partial class LoginViewModel : ViewModelBase
    {
        protected readonly OidcClient _client;
        IConnectivity _connectivity;
        private KeycloakService _keycloakService;

        public LoginViewModel(OidcClient client, IConnectivity connectivity, KeycloakService keycloakService)
        {
            _client = client;
            _connectivity = connectivity;
            _keycloakService = keycloakService;
        }

        [ICommand]
        async Task LoginAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (_connectivity.NetworkAccess is not NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Offline", "Check your internet connection!", "Ok");
                    return;
                }

                var loginResult = await _client.LoginAsync(new LoginRequest());
                if (loginResult.IsError)
                    return;

              

                var client = new HttpClient();

                var response = await client.IntrospectTokenAsync(new TokenIntrospectionRequest
                {
                    Address = "http://localhost:8080/realms/BP/protocol/openid-connect/token/introspect",
                    ClientId = "maui-app",
                    ClientSecret = "Owe8moSYgxR9Tx6MXEl5dSHIiySIgkET",

                    Token = loginResult.AccessToken
                }) ;

                _keycloakService.SetUserInfo("{" + response.Claims.FirstOrDefault(c => c.Type.ToString() == "realm_access").ToString() + "," + response.Claims.FirstOrDefault(c => c.Type.ToString() == "resource_access") + "}", loginResult.IdentityToken);

                if (_keycloakService.Authorize("ReadSubjects.*"))
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
                else
                    await Shell.Current.GoToAsync($"//{nameof(AccessDeniedPage)}", true);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

