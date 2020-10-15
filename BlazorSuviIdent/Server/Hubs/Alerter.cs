using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server.Hubs
{
	public class Alerter : Hub
	{
		public void Izmena()
		{
			Clients.All.SendAsync("Izmena");
		}
	}
}
