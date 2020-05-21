using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    class Game
	{
		private static List<IRule> DefaultRules = new List<IRule>
		{
			new EmptyCellRule(),
			new PlayerPieceSameColorRule()
		};

		public Board Board { get; } = new Board();
		public Color? Winner { get; private set; }
		public List<MoveRecord> History { get; } = new List<MoveRecord>();
		public List<IRule> Rules { get; } = DefaultRules;
		public bool IsDraw { get; private set; }

		public Game(IEnumerable<IRule> rules)
		{
			Rules = rules.ToList();
		}

		public Game()
		{
		}

		public Result TryMakeMove(MoveCommand move)
		{
			var error = Rules.Select(r => r.Validate(Board, move)).FirstOrDefault(r => !r.IsValid);
			if (error is object)
			{
				return Result.Error(error.Message);
			}

			var record = Board.ApplyMoveCommand(move);
			History.Add(record);
			if (CurrentPlayer == Color.White)
			{
				CurrentPlayer = Color.Black;
			}
			else
			{
				CurrentPlayer = Color.White;
			}

			return Result.Ok;
		}

		public bool IsOver => Winner.HasValue || IsDraw;

		public Color CurrentPlayer { get; private set; } = Color.White;
	}
}
