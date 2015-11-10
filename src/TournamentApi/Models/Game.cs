using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Models
{
	public class Game
	{
		[Key]
		public int Game_Id { get; set; }
		public string GameTitle { get; set; }
		public string GameImage { get; set; }
	}
}