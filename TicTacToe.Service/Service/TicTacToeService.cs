using TicTacToe.Service.EFData;
using TicTacToe.Service.IService;
using TicTacToe.Service.Models;

namespace TicTacToe.Service.Service
{
	public class TicTacToeService : ITicTacToeService
	{
		private readonly TicTacToeContext _context;

		public TicTacToeService(TicTacToeContext context)
		{
			_context = context;
		}
		public  void  AddResult (GameResult result)
		{

			 _context.GameResults.Add(result);
			_context.SaveChanges();

		}
	}
}
