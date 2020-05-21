namespace Chess
{
	class PawnMoveRule : PieceMoveRule
	{
		protected override Piece Piece => Piece.Pawn;

		protected override Result ValidateInternal(Board board, MoveCommand move)
		{
			return Result.Ok;
		}
	}
}
