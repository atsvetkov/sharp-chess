namespace Chess
{
    class PlayerPieceSameColorRule : IRule
	{
		public Result Validate(Board board, MoveCommand move)
		{
			if (!board.TryGetPiece(move.From, out var coloredPiece))
			{
				return Result.Ok;
			}

			var (_, color) = coloredPiece;

			return color == move.Player ? Result.Ok : Result.Error("That's not your piece");
		}
	}
}
