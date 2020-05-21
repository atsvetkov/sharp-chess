namespace Chess
{
	class ConsoleGameController
	{
		private readonly IInput _input;
		private readonly IOutput _output;

		public ConsoleGameController(IInput input, IOutput output)
		{
			_input = input;
			_output = output;
		}

		private Game _game = new Game();

		public void Start()
		{
			DisplayBoard();

			while (!_game.IsOver)
			{
				var moveString = _input.Read($"{_game.CurrentPlayer}'s turn:"); // e2 e4
				if (string.IsNullOrEmpty(moveString))
				{
					_output.UpdateStatus("Invalid move: please enter a command (e.g. \"e2 e4\")");
					continue;
				}

				if (moveString == "q")
				{
					_output.Message("Thanks for playing, goodbye!");
					break;
				}

				var moveStringParts = moveString.Split(' ');
				if (moveStringParts.Length != 2)
				{
					_output.UpdateStatus("Invalid move: could not parse user input");
					continue;
				}

				if (!Cell.TryParse(moveStringParts[0], out var from))
				{
					_output.UpdateStatus("Invalid move: incorrect 'from' cell");
					continue;
				}

				if (!Cell.TryParse(moveStringParts[1], out var to))
				{
					_output.UpdateStatus("Invalid move: incorrect 'to' cell");
					continue;
				}

				var move = new MoveCommand(_game.CurrentPlayer, from, to);
				var result = _game.TryMakeMove(move);
				if (!result.IsValid)
				{
					_output.UpdateStatus($"Invalid move: {result.Message}");
					continue;
				}

				DisplayBoard();
			}
		}

		private void DisplayBoard()
		{
			_output.Display(_game.Board);
		}
	}
}
