using System;
using IdentityModel.Client;
using System.Text.Json;
using IdentityModel.OidcClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using BPMobile.Keycloak;
using BPMobile.Views.Auth;
using BPMobile.Entities;
using BPMobile.Data.Repositories.Interfaces;

namespace BPMobile.ViewModels;

[QueryProperty("Token", "Token")]
public partial class MainViewModel : ViewModelBase
{
    protected readonly OidcClient _oidcClient;
    protected readonly HttpClient _httpClient;
    private KeycloakService _keycloakService;
    private readonly IRepositoryManager _repositoryManager;

    IConnectivity _connectivity;

    public MainViewModel(IRepositoryManager repositoryManager, KeycloakService keycloakService, OidcClient client, IConnectivity connectivity)
	{
        _oidcClient = client;
        _connectivity = connectivity;
        _keycloakService = keycloakService;
        _repositoryManager = repositoryManager;

        _subjects = _repositoryManager.Subjects.ListSubjects().ToList();
    }

    [ICommand]
    async Task LogoutAsync()
    {
        try
        {
            var logoutResult = await _oidcClient.LogoutAsync(new LogoutRequest()
            {
                IdTokenHint = _keycloakService._identityToken
            });
            _keycloakService.ClearUserInfo();

            await Shell.Current.DisplayAlert("Result", "Logout successful", "Continue");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
        }
    }

    private List<Subject> _subjects; // Assuming Subject is the class for your subjects

    public List<Subject> Subjects
    {
        get => _subjects;
        set
        {
            _subjects = value;
            OnPropertyChanged(); // Notify UI of property change
        }
    }
}


