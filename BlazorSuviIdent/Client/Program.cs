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

namespace BlazorSuviIdent.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddHttpClient("BlazorSuviIdent.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorSuviIdent.ServerAPI")); Treba specijalan klijent za tokene kasnije
			//mozda samo da se napravi za neuath dodatan?
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
