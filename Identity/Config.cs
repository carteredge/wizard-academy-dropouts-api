using Duende.IdentityServer.Models;

namespace Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name: "dropoutsApiUser", displayName: "Wizard Academy Dropouts API User"),
                // admin?
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client
                {
                    ClientId = "charSheet",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = 
                    {
                        new Secret(Environment.GetEnvironmentVariable("DropoutsIdentityClientSecret").Sha256())
                    },
                    AllowedScopes = { "dropoutsApi" }
                }
            };
}