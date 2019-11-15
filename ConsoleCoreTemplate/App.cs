using ConsoleCoreTemplate.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleCoreTemplate
{
	internal class App : IApp
	{
		private readonly ILogger<App> _logger;

		public App(ILogger<App> logger)
		{
			_logger = logger;
		}

		public Task Run()
		{
			_logger.LogInformation("Started Run");

			try
			{

			}
			catch(Exception e)
			{
				_logger.LogError($"[{MethodBase.GetCurrentMethod().Name}] {e.Message ?? ""}", e);
			}

			return Task.CompletedTask;
		}
	}
}
