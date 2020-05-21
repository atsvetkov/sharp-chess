namespace Chess
{
    abstract class PieceMoveRule : IRule
	{
		protected abstract Piece Piece { get; }

		public Result Validate(Board board, MoveCommand move)
		{
			if (!board.TryGetPiece(move.From, out (Piece, Color) coloredPiece) || Piece != coloredPiece.Item1)
			{
				return Result.Ok;
			}

			return ValidateInternal(board, move);
		}

		protected abstract Result ValidateInternal(Board board, MoveCommand move);
	}
}
