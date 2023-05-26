using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Webkit;

namespace BPMobile.Platforms.Android.Auth
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = CALLBACK_SCHEME)]
    public class MauiMaueWebAuthenticatorCallbackActivity : WebAuthenticatorCallbackActivity
	{
        const string CALLBACK_SCHEME = "maui-app";
    }
}

