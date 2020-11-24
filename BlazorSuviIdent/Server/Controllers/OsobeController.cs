using BlazorSuviIdent.Shared;
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
	public class OsobeController : ControllerBase
	{
		private readonly Baza _db;
		private readonly ILogger<OsobeController> _log;

		public OsobeController(Baza db, ILogger<OsobeController> log)
		{
			_log = log;
			_db = db;
		}

		[HttpGet]
		public IEnumerable<Osoba> NijeBitno()
		{
			return _db.Osobas.ToList();
		}

		[HttpPost]
		public void Editovanje([FromBody] Osoba o)
		{
			_log.LogInformation($"Dobio za edit: {o.Ime} {o.Prezime}");
			_db.Osobas.Update(o);
			_db.SaveChanges();
		}
	}
}
