using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IdentityServer4
{
    internal static class Constants
    {
        public static string IdentityServerName => "IdentityServer4";
        public static string IdentityServerAuthenticationType => IdentityServerName;
        public static string ExternalAuthenticationMethod => "external";
        public static string DefaultHashAlgorithm => "SHA256";

        public static TimeSpan DefaultCookieTimeSpan => TimeSpan.FromHours(10);
        public static TimeSpan DefaultCacheDuration => TimeSpan.FromMinutes(60);

        public static List<string> SupportedResponseTypes => new List<string>
        {
            OidcConstants.ResponseTypes.Code,
            OidcConstants.ResponseTypes.Token,
            OidcConstants.ResponseTypes.IdToken,
            OidcConstants.ResponseTypes.IdTokenToken,
            OidcConstants.ResponseTypes.CodeIdToken,
            OidcConstants.ResponseTypes.CodeToken,
            OidcConstants.ResponseTypes.CodeIdTokenToken
        };

        public static Dictionary<string, string> ResponseTypeToGrantTypeMapping => new Dictionary<string, string>
        {
            { OidcConstants.ResponseTypes.Code, GrantType.AuthorizationCode },
            { OidcConstants.ResponseTypes.Token, GrantType.Implicit },
            { OidcConstants.ResponseTypes.IdToken, GrantType.Implicit },
            { OidcConstants.ResponseTypes.IdTokenToken, GrantType.Implicit },
            { OidcConstants.ResponseTypes.CodeIdToken, GrantType.Hybrid },
            { OidcConstants.ResponseTypes.CodeToken, GrantType.Hybrid },
            { OidcConstants.ResponseTypes.CodeIdTokenToken, GrantType.Hybrid }
        };

        public static  List<string> AllowedGrantTypesForAuthorizeEndpoint => new List<string>
        {
            GrantType.AuthorizationCode,
            GrantType.Implicit,
            GrantType.Hybrid
        };

        public static  List<string> SupportedCodeChallengeMethods => new List<string>
        {
            OidcConstants.CodeChallengeMethods.Plain,
            OidcConstants.CodeChallengeMethods.Sha256
        };

        public enum ScopeRequirement
        {
            None,
            ResourceOnly,
            IdentityOnly,
            Identity
        }

        public static Dictionary<string, ScopeRequirement> ResponseTypeToScopeRequirement => new Dictionary<string, ScopeRequirement>
        {
            { OidcConstants.ResponseTypes.Code, ScopeRequirement.None },
            { OidcConstants.ResponseTypes.Token, ScopeRequirement.ResourceOnly },
            { OidcConstants.ResponseTypes.IdToken, ScopeRequirement.IdentityOnly },
            { OidcConstants.ResponseTypes.IdTokenToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeIdToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeIdTokenToken, ScopeRequirement.Identity }
        };

        public static Dictionary<string, IEnumerable<string>> AllowedResponseModesForGrantType => new Dictionary<string, IEnumerable<string>>
        {
            { GrantType.AuthorizationCode, new[] { OidcConstants.ResponseModes.Query, OidcConstants.ResponseModes.FormPost, OidcConstants.ResponseModes.Fragment } },
            { GrantType.Hybrid, new[] { OidcConstants.ResponseModes.Fragment, OidcConstants.ResponseModes.FormPost }},
            { GrantType.Implicit, new[] { OidcConstants.ResponseModes.Fragment, OidcConstants.ResponseModes.FormPost }}
        };

        public static  List<string> SupportedResponseModes => new List<string>
        {
            OidcConstants.ResponseModes.FormPost,
            OidcConstants.ResponseModes.Query,
            OidcConstants.ResponseModes.Fragment
        };

        public static string[] SupportedSubjectTypes =
        {
            "pairwise", "public"
        };

        public static class SigningAlgorithms
        {
            public static string RSA_SHA_256 => "RS256";
        }

        public static  List<string> SupportedDisplayModes => new List<string>
        {
            OidcConstants.DisplayModes.Page,
            OidcConstants.DisplayModes.Popup,
            OidcConstants.DisplayModes.Touch,
            OidcConstants.DisplayModes.Wap
        };

        public static  List<string> SupportedPromptModes => new List<string>
        {
            OidcConstants.PromptModes.None,
            OidcConstants.PromptModes.Login,
            OidcConstants.PromptModes.Consent,
            OidcConstants.PromptModes.SelectAccount
        };

        public static class KnownAcrValues
        {
            public const string HomeRealm = "idp:";
            public const string Tenant = "tenant:";

            public static readonly string[] All = { HomeRealm, Tenant };
        }

        public static Dictionary<string, int> ProtectedResourceErrorStatusCodes => new Dictionary<string, int>
        {
            { OidcConstants.ProtectedResourceErrors.InvalidToken,      401 },
            { OidcConstants.ProtectedResourceErrors.ExpiredToken,      401 },
            { OidcConstants.ProtectedResourceErrors.InvalidRequest,    400 },
            { OidcConstants.ProtectedResourceErrors.InsufficientScope, 403 }
        };

        public static Dictionary<string, IEnumerable<string>> ScopeToClaimsMapping => new Dictionary<string, IEnumerable<string>>
        {
            { IdentityServerConstants.StandardScopes.Profile, new[]
                            {
                                JwtClaimTypes.Name,
                                JwtClaimTypes.FamilyName,
                                JwtClaimTypes.GivenName,
                                JwtClaimTypes.MiddleName,
                                JwtClaimTypes.NickName,
                                JwtClaimTypes.PreferredUserName,
                                JwtClaimTypes.Profile,
                                JwtClaimTypes.Picture,
                                JwtClaimTypes.WebSite,
                                JwtClaimTypes.Gender,
                                JwtClaimTypes.BirthDate,
                                JwtClaimTypes.ZoneInfo,
                                JwtClaimTypes.Locale,
                                JwtClaimTypes.UpdatedAt
                            }},
            { IdentityServerConstants.StandardScopes.Email, new[]
                            {
                                JwtClaimTypes.Email,
                                JwtClaimTypes.EmailVerified
                            }},
            { IdentityServerConstants.StandardScopes.Address, new[]
                            {
                                JwtClaimTypes.Address
                            }},
            { IdentityServerConstants.StandardScopes.Phone, new[]
                            {
                                JwtClaimTypes.PhoneNumber,
                                JwtClaimTypes.PhoneNumberVerified
                            }},
            { IdentityServerConstants.StandardScopes.OpenId, new[]
                            {
                                JwtClaimTypes.Subject
                            }}
        };

        public static class UIConstants
        {
            // the limit after which old messages are purged
            public const int CookieMessageThreshold = 2;

            public static class DefaultRoutePathParams
            {
                public const string Error = "errorId";
                public const string Login = "returnUrl";
                public const string Consent = "returnUrl";
                public const string Logout = "logoutId";
                public const string EndSessionCallback = "endSessionId";
                public const string Custom = "returnUrl";
                public const string UserCode = "userCode";
            }

            public static class DefaultRoutePaths
            {
                public const string Login = "/account/login";
                public const string Logout = "/account/logout";
                public const string Consent = "/consent";
                public const string Error = "/home/error";
                public const string DeviceVerification = "/device";
            }
        }

        public static class EndpointNames
        {
            public const string Authorize = "Authorize";
            public const string Token = "Token";
            public const string DeviceAuthorization = "DeviceAuthorization";
            public const string Discovery = "Discovery";
            public const string Introspection = "Introspection";
            public const string Revocation = "Revocation";
            public const string EndSession = "Endsession";
            public const string CheckSession = "Checksession";
            public const string UserInfo = "Userinfo";
        }

        public static class ProtocolRoutePaths
        {
            public const string ConnectPathPrefix = "connect";

            public static string Authorize => ConnectPathPrefix + "/authorize";
            public static string AuthorizeCallback => Authorize + "/callback";
            public static string DiscoveryConfiguration => ".well-known/openid-configuration";
            public static string DiscoveryWebKeys => DiscoveryConfiguration + "/jwks";
            public static string Token => ConnectPathPrefix + "/token";
            public static string Revocation => ConnectPathPrefix + "/revocation";
            public static string UserInfo => ConnectPathPrefix + "/userinfo";
            public static string Introspection => ConnectPathPrefix + "/introspect";
            public static string EndSession => ConnectPathPrefix + "/endsession";
            public static string EndSessionCallback => EndSession + "/callback";
            public static string CheckSession => ConnectPathPrefix + "/checksession";
            public static string DeviceAuthorization => ConnectPathPrefix + "/deviceauthorization";

            public static string MtlsPathPrefix => ConnectPathPrefix + "/mtls";
            public static string MtlsToken => MtlsPathPrefix + "/token";
            public static string MtlsRevocation => MtlsPathPrefix + "/revocation";
            public static string MtlsIntrospection => MtlsPathPrefix + "/introspect";
            public static string MtlsDeviceAuthorization => MtlsPathPrefix + "/deviceauthorization";

            public static readonly string[] CorsPaths =
            {
                DiscoveryConfiguration,
                DiscoveryWebKeys,
                Token,
                UserInfo,
                Revocation
            };
        }

        public static class EnvironmentKeys
        {
            public const string IdentityServerBasePath = "idsvr:IdentityServerBasePath";
            [Obsolete("The IdentityServerOrigin constant is obsolete.")]
            public const string IdentityServerOrigin = "idsvr:IdentityServerOrigin"; // todo: deprecate
            public const string SignOutCalled = "idsvr:IdentityServerSignOutCalled";
        }

        public static class TokenTypeHints
        {
            public static string RefreshToken => "refresh_token";
            public static string AccessToken => "access_token";
        }

        public static List<string> SupportedTokenTypeHints = new List<string>
        {
            TokenTypeHints.RefreshToken,
            TokenTypeHints.AccessToken
        };

        public static class RevocationErrors
        {
            public const string UnsupportedTokenType = "unsupported_token_type";
        }

        public class Filters
        {
            // filter for claims from an incoming access token (e.g. used at the user profile endpoint)
            public static readonly string[] ProtocolClaimsFilter = {
                JwtClaimTypes.AccessTokenHash,
                JwtClaimTypes.Audience,
                JwtClaimTypes.AuthorizedParty,
                JwtClaimTypes.AuthorizationCodeHash,
                JwtClaimTypes.ClientId,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.JwtId,
                JwtClaimTypes.Nonce,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.ReferenceTokenId,
                JwtClaimTypes.SessionId,
                JwtClaimTypes.Scope
            };

            // filter list for claims returned from profile service prior to creating tokens
            public static readonly string[] ClaimsServiceFilterClaimTypes = {
                // TODO: consider JwtClaimTypes.AuthenticationContextClassReference,
                JwtClaimTypes.AccessTokenHash,
                JwtClaimTypes.Audience,
                JwtClaimTypes.AuthenticationMethod,
                JwtClaimTypes.AuthenticationTime,
                JwtClaimTypes.AuthorizedParty,
                JwtClaimTypes.AuthorizationCodeHash,
                JwtClaimTypes.ClientId,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IdentityProvider,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.JwtId,
                JwtClaimTypes.Nonce,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.ReferenceTokenId,
                JwtClaimTypes.SessionId,
                JwtClaimTypes.Subject,
                JwtClaimTypes.Scope,
                JwtClaimTypes.Confirmation
            };

            public static readonly string[] JwtRequestClaimTypesFilter = {
                JwtClaimTypes.Audience,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.JwtId
            };
        }

        public static class WsFedSignOut
        {
            public const string LogoutUriParameterName = "wa";
            public const string LogoutUriParameterValue = "wsignoutcleanup1.0";
        }

        public static class AuthorizationParamsStore
        {
            public const string MessageStoreIdParameterName = "authzId";
        }

        public static class CurveOids
        {
            public const string P256 = "1.2.840.10045.3.1.7";
            public const string P384 = "1.3.132.0.34";
            public const string P521 = "1.3.132.0.35";
        }
    }
}