using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureKeyVaultDemo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ValuesController : ControllerBase
	{
		private readonly ILogger<ValuesController> _logger;
		private readonly IConfiguration _configuration;

		public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[HttpGet]
		public IEnumerable<String> Get()
		{
			var key1 = _configuration["SecretKey1"];//This should come from appsettings.json
			var key2 = _configuration["SecretKey2"];//This should come from azure key vault

			var keyValues = new List<string>() { key1, key2 };
			return keyValues;
		}
	}
}
