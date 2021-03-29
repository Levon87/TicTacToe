using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TicTacToe.Service.IService;
using TicTacToe.Service.Models;

namespace TicTacToe.Service.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITicTacToeService _ticTacToeService;
		static string[] turns = new[] { "#", "#", "#", "#", "#", "#", "#", "#", "#" };
		public static string computerTurn = "";
		public static string turn = "";
		static bool gameOn = false;
		static int count = 0;
		public static string gamer;
		public HomeController(ITicTacToeService ticTacToeService)
		{
			_ticTacToeService = ticTacToeService;
		}

		public IActionResult Index()
		{
			return View();
		}


		public IActionResult ChooseGamer(string startTurn)
		{
			gamer = startTurn;
			switch (startTurn)
			{
				case "X":
					computerTurn = "O";
					turn = "X";
					break;
				case "O":
					computerTurn = "X";
					turn = "O";
					break;
				case null:
				default:
					throw new System.Exception();
			}

			return Ok();
		}
		public int ComputersTurn()
		{
			Random random = new Random();
			var taken = false;
			while (!taken && count != 5)
			{
				var computerMove = random.Next(9);
				var move = turns[computerMove];
				if (move == "#")
				{
					turns[computerMove] = computerTurn;
					taken = true;
					turns[computerMove] = computerTurn;

					return computerMove;
				}
			}
			return -1;
		}

		public JsonResult playerTurn(int id)
		{
			int computerturnId = 0;
			string message = string.Empty;		
			var spotTaken = turns[id];
			if (spotTaken == "#")
			{
				count++;
				turns[id] = turn;
				message = winCondition(turn, id, computerturnId);

				if (gameOn == false)
				{
					computerturnId = ComputersTurn();
					
					message = winCondition(computerTurn, id, computerturnId);
				}
			}
			return new JsonResult(new { id = id, message = message, turn = turn, computerturnId = computerturnId, computerTurn = computerTurn, gameOn = gameOn, isDraw = !turns.Any(item => item == "#") });
		}
		public string winCondition(string computerTurn, int id, int computerturnId)
		{
			GameResult gameResult = new GameResult();
			gameResult.ResultDate = DateTime.Now;
			string message = string.Empty;

			if (turns[0] == computerTurn && turns[1] == computerTurn && turns[2] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[2] == computerTurn && turns[4] == computerTurn && turns[6] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}
				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);

			}
			else if (turns[0] == computerTurn && turns[3] == computerTurn && turns[6] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}
				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);

			}
			else if (turns[0] == computerTurn && turns[4] == computerTurn && turns[8] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}
				
				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[1] == computerTurn && turns[4] == computerTurn && turns[7] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[2] == computerTurn && turns[5] == computerTurn && turns[8] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[2] == computerTurn && turns[5] == computerTurn && turns[8] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[3] == computerTurn && turns[4] == computerTurn && turns[5] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (turns[6] == computerTurn && turns[7] == computerTurn && turns[8] == computerTurn)
			{
				gameOn = true;
				reset();

				if (gamer == computerTurn)
				{
					message = "gamer  won. He was " + computerTurn;
				}
				else
				{
					message = "Computer  won.He was" + computerTurn;
				}

				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else if (!turns.Contains("#"))
			{
				gameOn = true;
				reset();
				message = "It is a Draw!";
				gameResult.Result = message;
				_ticTacToeService.AddResult(gameResult);


			}
			else
			{
				gameOn = false;
			}

			return message;
		}
		public IActionResult reset()
		{
			turns = new[] { "#", "#", "#", "#", "#", "#", "#", "#", "#" };
			count = 0;
			gameOn = true;

			return Ok();
		}
	}
}
