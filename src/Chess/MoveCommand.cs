namespace Chess
{
	class MoveCommand
	{
		public Color Player { get; }
		public Cell From { get; }
		public Cell To { get; }

		public MoveCommand(Color player, Cell from, Cell to)
		{
			Player = player;
			From = from;
			To = to;
		}

		public void Deconstruct(out Color player, out Cell from, out Cell to)
		{
			player = Player;
			from = From;
			to = To;
		}
	}
}
