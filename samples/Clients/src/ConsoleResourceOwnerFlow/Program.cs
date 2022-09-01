using Clients;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleResourceOwnerFlow
{
    public class Program
    {
        static async Task Main()
        {
            Console.Title = "Console ResourceOwner Flow";

            var response = await RequestTokenAsync();
            response.Show();

            Console.ReadLine();
            await CallServiceAsync(response.AccessToken);
        }

        static async Task<TokenResponse> RequestTokenAsync()
        {
            var client = new HttpClient();

            DiscoveryDocumentRequest documentRequest = new DiscoveryDocumentRequest();
            documentRequest.Address = Constants.Authority;
            documentRequest.Policy = new DiscoveryPolicy()
            {
                RequireHttps = false,
                ValidateIssuerName = false,
                ValidateEndpoints = false
            };
            var disco = await client.GetDiscoveryDocumentAsync(documentRequest);
            if (disco.IsError) throw new Exception(disco.Error);

            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "Awesome_Web",
                ClientSecret = "1q2w3e*",

                UserName = "8888@Abp.VNext.Hello.com",
                Password = "8888@Abp.VNext.Hello.com",

                Scope = "profile role",

                Parameters =
                {
                    { "acr_values", "tenant:custom_account_store1 foo bar quux" }
                }
            });

            if (response.IsError) throw new Exception(response.Error);
            return response;
        }

        static async Task CallServiceAsync(string token)
        {
            var baseAddress = Constants.SampleApi;

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            client.SetBearerToken(token);
            var response = await client.GetStringAsync("identity");

            "\n\nService claims:".ConsoleGreen();
            Console.WriteLine(JArray.Parse(response));
        }
    }
}