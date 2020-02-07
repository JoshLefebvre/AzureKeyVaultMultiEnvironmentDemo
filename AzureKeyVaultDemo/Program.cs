using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AzureKeyVaultDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
				{
					//Registers adtitional sources to IConfigurationBuilder
					configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile($"azurekeyvault.json", true, true)
						.AddJsonFile($"azurekeyvault.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true);

					//Builds IConfiguration with keys and values from the set of sources registered in IConfigurationBuilder
					//and returns IConfigurationRoot with keys and values from the registered sources.
					var configuration = configurationBuilder.Build();

					//Retrieve config values from sources
					string keyVaultEndpoint = configuration["AzureKeyVault:Endpoint"];
					string clientId = configuration["AzureKeyVault:ClientId"];
					string clientSecret = configuration["AzureKeyVault:ClientSecret"];

					//Registers the IConfigurationProvider that reads configuration values from the Azure KeyVault.
					configurationBuilder.AddAzureKeyVault(keyVaultEndpoint, clientId, clientSecret);
				});
	}
}
