using ConsoleCoreTemplate.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCoreTemplate
{
	class Program
	{
		private static IServiceProvider serviceProvider;
		private static IConfiguration configuration;

		static async Task Main(string[] args)
		{
			SetConfiguration();
			ConfigureServices();
			var app = serviceProvider.GetService<IApp>();

			await app.Run();
			
			Console.WriteLine("Done. Closing in 2 seconds.");
			Thread.Sleep(2000);
			Environment.Exit(0);
		}

		private static void SetConfiguration()
		{
			try
			{
				DotNetEnv.Env.Load();
			}
			catch(Exception)
			{
				Console.WriteLine($".env file not found.");
			}

			configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", true, true)
				.Build();
		}

		private static void ConfigureServices()
		{
			serviceProvider = new ServiceCollection()
				.AddLogging(x => x.AddConsole())
				.AddSingleton<IApp, App>()
				.BuildServiceProvider();
		}
	}
}
