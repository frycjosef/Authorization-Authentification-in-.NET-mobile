using System;
namespace BPMobile.Keycloak
{
    public class KeycloakSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; } 
        public string Realm { get; set; }
        public string AuthServerUrl { get; set; }
        public string LogoutEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string TokenIntrospectEndpoint { get; set; }
        public string RedirectUri { get; set; }
        public string Scope { get; set; }
    }
}

