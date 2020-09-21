using BlazorSuviIdent.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server.Hubs
{
	public class UserMan : Hub
	{
		public UserMan(RoleManager<IdentityRole> rm, UserManager<IdentityUser> um)
		{
			_rm = rm;
			_um = um;
		}

		private readonly RoleManager<IdentityRole> _rm;
		private readonly UserManager<IdentityUser> _um;

		public async Task GetRoles() =>
			await Clients.Caller.SendAsync("RecRoles", _rm.Roles.Select(r => r.Name).ToList());

		public async Task Register(Registracija reg)
		{
			var greske = new List<string>();

			var user = new IdentityUser { Email = reg.Mejl, UserName = reg.Uname };
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
	}
}
