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

		public void Deconstruct(out string ID, out string Ime, out string Prezime)
		{
			ID = this.ID;
			Ime = this.Ime;
			Prezime = this.Prezime;
		}
	}
}
