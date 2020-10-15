using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using zklj;

namespace BlazorSuviIdent.Server.Services
{
	public class ProbniServ : zklj.ProbniServis.ProbniServisBase
	{
		private readonly SignInManager<IdentityUser> _sim;

		public ProbniServ(SignInManager<IdentityUser> sim)
		{
			_sim = sim;
		}


		public override Task<TestPoruka> ProbniPoziv(TestPoruka req, ServerCallContext context)
		{
			return Task.FromResult(new TestPoruka { Nesto = $"Od servera: {req.Nesto}" });
		}

		public override async Task<LoginOdg> Login(LoginPoruka request, ServerCallContext context)
		{
			var rez = await _sim.PasswordSignInAsync(request.Kor, request.Pass, false, false);
			if (!rez.Succeeded)
			{
				return new LoginOdg { Uspeh = false };
			}
			return new LoginOdg { Uspeh = true };
		}
	}
}
