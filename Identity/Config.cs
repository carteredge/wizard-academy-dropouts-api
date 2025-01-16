using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Identity.Helpers;

namespace Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [ 
            new IdentityResources.OpenId(),
            new IdentityResources.Email()
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope(name: "dropoutsApiUser", displayName: "Wizard Academy Dropouts API User"),
            // admin?
        ];

    public static IEnumerable<Client> Clients =>
        [
            // new Client
            // {
            //     ClientId = "charSheet",
            //     AllowedGrantTypes = GrantTypes.ClientCredentials,
            //     ClientSecrets = 
            //     {
            //         new Secret(Environment.GetEnvironmentVariable("DropoutsIdentityClientSecret").Sha256())
            //     },
            //     AllowedScopes = { "dropoutsApi" }
            // },
            new Client
            {
                ClientId = "web",
                ClientSecrets =
                {
                    new Secret(Environment.GetEnvironmentVariable("DropoutsIdentityClientSecret").Sha256())
                },
                AllowAccessTokensViaBrowser = true,
                AllowedGrantTypes = GrantTypes.Code,
                AlwaysIncludeUserClaimsInIdToken = true,
                AlwaysSendClientClaims = true,
                RedirectUris = UrlHelper.GetAllowedUrls(),
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = {
                    // "dropoutsApi",
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                }
            }
        ];
}