using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;

namespace TournamentApi.Models
{
	public class Match
	{
		[Key]
		public int Match_ID { get; set; }
		public virtual Game Match_Game { get; set; }
		
	}
}