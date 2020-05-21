namespace Chess
{
	class EmptyCellRule : IRule
	{
		public Result Validate(Board board, MoveCommand move)
		{
			if (!board.TryGetPiece(move.From, out var _))
			{
				return Result.Error("Nothing to move");
			}

			return Result.Ok;
		}
	}
}
