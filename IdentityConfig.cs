using System;
using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using static IdentityServer4.IdentityServerConstants;
using IdentityServer4;

namespace IdentityServer
{
    public static class IdentityConfig
    {
        private const string ApiResourceName = "api";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(ApiResourceName, "My Protected API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { ApiResourceName }
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { ApiResourceName }
                },

                ///////////////////////////////////////////
                // Console Public Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "roclient.public",
                    ClientName = "roclient.public",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,

                    AllowedScopes = new List<string>
                    {
                        ApiResourceName,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    }
                },
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}