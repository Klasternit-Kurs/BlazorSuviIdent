using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using zklj;

namespace BlazorSuviIdent.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

            //Visak lol
			//builder.Services.AddHttpClient("BlazorSuviIdent.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
			//	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorSuviIdent.ServerAPI"));
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddApiAuthorization()
				.AddAccountClaimsPrincipalFactory<RolesFactory>();

            builder.Services.AddSingleton<Primer>();

            builder.Services.AddSingleton(s =>
            {
                var uri = s.GetRequiredService<NavigationManager>().BaseUri;
                var hc = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
                var kanal = GrpcChannel.ForAddress(uri, new GrpcChannelOptions { HttpClient = hc });
                return new ProbniServis.ProbniServisClient(kanal);
            });

			await builder.Build().RunAsync();
		}
	}

    public class RolesFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        public RolesFactory(IAccessTokenProviderAccessor accessor)
            : base(accessor)
        {
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
            RemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);

            if (user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var roleClaims = identity.FindAll(identity.RoleClaimType);

                if (roleClaims != null && roleClaims.Any())
                {
                    foreach (var existingClaim in roleClaims)
                    {
                        identity.RemoveClaim(existingClaim);
                    }

                    var rolesElem = account.AdditionalProperties[identity.RoleClaimType];

                    if (rolesElem is JsonElement roles)
                    {
                        if (roles.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var role in roles.EnumerateArray())
                            {
                                identity.AddClaim(new Claim(options.RoleClaim, role.GetString()));
                            }
                        }
                        else
                        {
                            identity.AddClaim(new Claim(options.RoleClaim, roles.GetString()));
                        }
                    }
                }
            }

            return user;
        }
    }
}
