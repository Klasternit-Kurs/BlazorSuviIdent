using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSuviIdent.Shared
{
	public class Osoba
	{
		public string ID { get; set; } = Guid.NewGuid().ToString();
		public string Ime { get; set; }
		public string Prezime { get; set; }
	}
}
