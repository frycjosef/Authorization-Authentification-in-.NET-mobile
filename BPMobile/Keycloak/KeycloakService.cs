using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Maui.Authentication;

namespace BPMobile.Keycloak
{
    public partial class KeycloakService
    {
        private Token token;
        public string _identityToken;

        public void SetUserInfo(string json, string identityToken = null)
        {
            token = new Token(json);
            _identityToken = identityToken ?? "";
        }

        public void ClearUserInfo()
        {
            token = null;
        }

        public bool Authorize(string permissionName)
        {
            if (token is null)
                return false;

            // Check for exact permission
            if (token.ClientPermissions.Contains(permissionName) || token.RealmPermissions.Contains(permissionName))
            {
                return true;
            }

            // Check for wildcard permission
            if (permissionName.EndsWith(".*"))
            {
                string basePermission = permissionName.Substring(0, permissionName.Length - 2);
                if (token.ClientPermissions.Contains(basePermission) || token.RealmPermissions.Contains(basePermission))
                {
                    return true;
                }

                // Check for specific permissions with the same base permission
                string specificPermissionPrefix = basePermission + ".";
                foreach (string clientPermission in token.ClientPermissions)
                {
                    if (clientPermission.StartsWith(specificPermissionPrefix))
                    {
                        return true;
                    }
                }

                foreach (string realmPermission in token.RealmPermissions)
                {
                    if (realmPermission.StartsWith(specificPermissionPrefix))
                    {
                        return true;
                    }
                }
            }

            // Check for all permission levels
            while (permissionName.Contains("."))
            {
                int lastDotIndex = permissionName.LastIndexOf('.');
                permissionName = permissionName.Substring(0, lastDotIndex);

                if (token.ClientPermissions.Contains(permissionName) || token.RealmPermissions.Contains(permissionName))
                {
                    return true;
                }
            }

            return false;
        }
    }


}

