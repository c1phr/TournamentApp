using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;
using System.Collections.Generic;

namespace TournamentApi.Models
{
	public class Match
	{
		[Key]
		public int MatchID { get; set; }
		public int Round { get; set; }
		public string Team1 {get; set;}
		public string Team2 { get; set; }
		public string Status { get; set; }
		public virtual Game Match_Game { get; set; }
		
	}
}