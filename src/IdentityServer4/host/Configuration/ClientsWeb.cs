// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.using System.Collections.Generic;

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServerHost.Configuration
{
    public static class ClientsWeb
    {
        static string[] allowedScopes =
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.Phone,
            IdentityServerConstants.StandardScopes.Address,
           // IdentityServerConstants.StandardScopes.OfflineAccess,
            "role",
            "Exam"
        };


        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "Awesome_Web",
                    ClientName = "Awesome_Web",
                    ClientSecrets={ new Secret("1q2w3e") },
                    ClientUri = "http://106.13.130.51:8080",
                    AllowedGrantTypes =GrantTypes.Code,// GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret = false,
                    RequirePkce=false,
                    RedirectUris =
                    {
                        "http://192.168.1.4:44383/swagger/oauth2-redirect.html",
                        "http://localhost:44307/authentication/login-callback",
                        "https://localhost:44300/signin-oidc",
                        "http://localhost:44307",
                        "http://106.13.130.51:8080/signin-idsrv"
                    },

                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },
                    AllowedCorsOrigins = {
                        "http://192.168.1.4:44383",
                        "https://localhost:44383",
                        "http://localhost:44307",
                        "http://106.13.130.51:8080"
                    },
                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Automatic Token Management Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.tokenmanagement",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AccessTokenLifetime = 75,

                    RedirectUris = { "https://localhost:44301/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44301/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44301/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Code Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.code",
                    ClientName = "MVC Code Flow",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RequireConsent = true,
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44302/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44302/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44302/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Hybrid Flow Sample (Back Channel logout)
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.hybrid.backchannel",
                    ClientName = "MVC Hybrid (with BackChannel logout)",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,

                    RedirectUris = { "https://localhost:44303/signin-oidc" },
                    BackChannelLogoutUri = "https://localhost:44303/logout",
                    PostLogoutRedirectUris = { "https://localhost:44303/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                }
            };
        }
    }
}