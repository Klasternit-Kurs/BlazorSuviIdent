using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server.Modeli
{
	public class NekiMojJuzer : IdentityUser
	{
		public string Nesto { get; set; }
		public string BlaBla { get; set; }
	}
}
