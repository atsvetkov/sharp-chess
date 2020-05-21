namespace Chess
{
    class MoveRecord
	{
		public MoveRecord(Color color, Piece piece, Cell from, Cell to)
		{
			Color = color;
			Piece = piece;
			From = from;
			To = to;
		}

		public Color Color { get; }
		public Piece Piece { get; }
		public Cell From { get; }
		public Cell To { get; }

		public override string ToString() => $"{Color}: {Piece} {From} {To}";
	}
}
