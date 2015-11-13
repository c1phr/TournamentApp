using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TournamentApi.Models;

namespace TournamentApi.Controllers
{
	[Route("api/[controller]")]
	public class GamesController : Controller
	{
		private TournamentContext db = new TournamentContext();
		
		[HttpGet]
		public IEnumerable<Game> Get()
		{
			var games = db.Games;
			return games;
		}				
	}
}