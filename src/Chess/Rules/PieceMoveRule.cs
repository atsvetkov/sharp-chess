namespace Chess
{
    abstract class PieceMoveRule : IRule
	{
		protected abstract Piece Piece { get; }

		public Result Validate(Board board, MoveCommand move)
		{
			if (!board.TryGetPiece(move.From, out (Piece piece, Color color) coloredPiece) || Piece != coloredPiece.piece)
			{
				return Result.Ok;
			}

			return ValidateInternal(board, move, coloredPiece.piece, coloredPiece.color);
		}

		protected abstract Result ValidateInternal(Board board, MoveCommand move, Piece piece, Color color);
	}
}
