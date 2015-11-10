using Microsoft.Data.Entity;

namespace TournamentApi.Models
{
	public class TournamentContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=./tournament.db");
		}
	}
}