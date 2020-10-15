using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Client
{
	public class Primer
	{
		private int _broj;
		public int Broj 
		{ 
			get => _broj;
			set
			{
				_broj = value;
				OnPromena?.Invoke();
			} 
		}

		public event Action OnPromena;
	}
}
