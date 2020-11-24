using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSuviIdent.Shared
{
	public class Osoba : IdentityUser
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		
	}
}
