using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TournamentApi.Models;
using Microsoft.Data.Entity;

namespace TournamentApi.Controllers
{
	[Route("api/[controller]")]
	public class MatchController : Controller
	{
		private TournamentContext db = new TournamentContext();
		
		[HttpGet]
		public IEnumerable<Match> Get()
		{
			return db.Matches.Include(m => m.Match_Game);
		}
		
		[HttpGet("{shortcode}")]
		public IEnumerable<Match> Get(string shortcode)
		{
			if (!string.IsNullOrWhiteSpace(shortcode))
			{
				return db.Matches.Where(m => m.Match_Game.Shortcode == shortcode).Include(m => m.Match_Game);
			}
			return null;
		}
	}
}