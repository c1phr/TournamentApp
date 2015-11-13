using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Shortcode { get; set; }
		public string ImageUrl { get; set; }
	}
}