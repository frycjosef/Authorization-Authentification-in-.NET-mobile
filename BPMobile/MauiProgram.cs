using BPMobile.Data;
using BPMobile.ViewModels;
using BPMobile.ViewModels.Auth;
using BPMobile.Keycloak;
using IdentityModel.OidcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;
using BPMobile.Data.Repositories.Interfaces;

namespace BPMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddEntityFrameworkMySQL().AddDbContext<BPContext>(options =>
        {
            options.UseMySQL("server=localhost;port=3306;user=root;password=my-secret-pw;database=BP-scheme");
        });


        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<AccessDeniedViewModel>();
        builder.Services.AddSingleton<KeycloakService>();
        builder.Services.AddSingleton<Views.Auth.LoginPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AccessDeniedPage>();

        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();



        builder.Services.AddTransient<WebAuthenticatorBrowser>();

        builder.Services.AddTransient<OidcClient>(sp =>
        new OidcClient(new OidcClientOptions
        {
            Authority = "http://localhost:8080/realms/BP",
            ClientId = "maui-app",
            Scope = "openid profile",
            RedirectUri = "maui-app://auth/redirect",
            PostLogoutRedirectUri = "maui-app://auth/redirect",
            ClientSecret = "Owe8moSYgxR9Tx6MXEl5dSHIiySIgkET",
            Browser = sp.GetRequiredService<WebAuthenticatorBrowser>()
        }));

        return builder.Build();
    }
}

