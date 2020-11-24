using BlazorSuviIdent.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server.Hubs
{
	public class UserMan : Hub
	{
		public UserMan(RoleManager<IdentityRole> rm, UserManager<IdentityUser> um, ILogger<UserMan> logger, Baza b2)
		{
			_rm = rm;
			_um = um;
			_logger = logger;
			_dbTest = b2;
		}

		private readonly RoleManager<IdentityRole> _rm;
		private readonly UserManager<IdentityUser> _um;
		private readonly ILogger<UserMan> _logger;
		private readonly Baza _dbTest;

		public async Task GetRoles() =>
			await Clients.Caller.SendAsync("RecRoles", _rm.Roles.Select(r => r.Name).ToList());

		public async Task Register(Registracija reg)
		{
			var greske = new List<string>();

			var user = new Osoba { Email = reg.Mejl, UserName = reg.Uname};
			var rez = await _um.CreateAsync(user, reg.Sifra);

			if (rez.Succeeded)
			{
				var roleRez = await _um.AddToRoleAsync(user, reg.Rola);
				greske = roleRez.Errors.Select(err => err.Description).ToList();
				await Clients.Caller.SendAsync("RegResult", roleRez.Succeeded, greske);
				return;
			}

			greske = rez.Errors.Select(err => err.Description).ToList();
			await Clients.Caller.SendAsync("RegResult", rez.Succeeded, greske);
		}

		[Authorize]
		public void Auth()
		{

			_logger.LogInformation("Call authorized");
		}

		[Authorize(Roles = "Admin")]
		public void AuthAdmin()
		{
			_logger.LogInformation("Call authorized, admin");
		}

	}
}
