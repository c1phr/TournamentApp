using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TournamentApi.Models;
using Microsoft.Data.Entity;
using TournamentApi.ViewModels;

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

        [HttpPost]
        public Match Post([FromBody]MatchViewModel newMatchVm)
        {
            Match newMatch = new Match();
			newMatch.Match_Game = db.Games.First(g => g.Shortcode == newMatchVm.GameShortcode);
			newMatch.Round = newMatchVm.Round;
			newMatch.Team1 = newMatchVm.Team1;
			newMatch.Team2 = newMatchVm.Team2;
			newMatch.Status = newMatchVm.Status;
			var newDbMatch = db.Matches.Add(newMatch);
			db.SaveChanges();
            return newDbMatch.Entity;
        }
	}
}