using Microsoft.EntityFrameworkCore;
using TicTacToe.Service.Models;

namespace TicTacToe.Service.EFData
{
	public class TicTacToeContext : DbContext
	{
		public TicTacToeContext(DbContextOptions<TicTacToeContext> options)
			   : base(options)
		{
		}

		public DbSet<GameResult> GameResults { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<GameResult>()
						  .HasKey(result => new { result.Id });

		}

	}
}
