﻿using System;
using Newtonsoft.Json.Linq;

namespace BPMobile.Keycloak
{
	public class Token
	{
        public Token(string json)
        {

            JObject jObject = JObject.Parse(json);
            var jRealmPermissions = jObject["realm_access"]?["roles"] as JArray;
            RealmPermissions = jRealmPermissions != null ? jRealmPermissions.Select(p => p.ToString()).ToArray() : new string[] { };
            var jClientPermissions = jObject["resource_access"]?["account"]?["roles"] as JArray;
            ClientPermissions = jClientPermissions != null ? jClientPermissions.Select(p => p.ToString()).ToArray() : new string[] { };
        }

        public string[] RealmPermissions { get; set; }
        public string[] ClientPermissions { get; set; }
    }
}

