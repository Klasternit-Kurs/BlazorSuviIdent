using BlazorSuviIdent.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LogInController : ControllerBase
	{
		private readonly ILogger<LogInController> _logger;
		private readonly SignInManager<IdentityUser> _sim;

		public LogInController(ILogger<LogInController> logger, SignInManager<IdentityUser> sim)
		{
			_logger = logger;
			_sim = sim;
		}

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Registracija reg)
        {
			_logger.LogInformation($"Got request for: {reg.Uname}");
            var rez = await _sim.PasswordSignInAsync(reg.Uname, reg.Sifra, false, false);
			if (!rez.Succeeded)
			{
				_logger.LogWarning($"Failed to log in");
				return BadRequest();
			}
			_logger.LogInformation("Logged in user.");
			return Ok();
        }
    }
}
