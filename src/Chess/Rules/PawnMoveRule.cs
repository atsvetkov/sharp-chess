using System;

namespace Chess
{
    class PawnMoveRule : PieceMoveRule
	{
		protected override Piece Piece => Piece.Pawn;

		protected override Result ValidateInternal(Board board, MoveCommand move, Piece piece, Color color)
		{
			var isInOriginalCell = (color == Color.White && move.From.Y == 2) || (color == Color.Black && move.From.Y == 7);
			var maxDistance = isInOriginalCell ? 2 : 1;
			if (move.From.Y > move.To.Y && color == Color.White)
            {
				return Result.Error("White pawns can only move up");
            }

			if (move.From.Y < move.To.Y && color == Color.Black)
			{
				return Result.Error("Black pawns can only move down");
			}

			if (Math.Abs(move.From.Y - move.To.Y) > maxDistance)
            {
				return Result.Error("Pawns can't go that far");
            }

			var step = color == Color.White ? 1 : -1;
			for (var y = move.From.Y + step; y <= move.From.Y + maxDistance * step; y += step)
            {
				if (board.IsOccupied(new Cell(move.From.X, y)))
                {
					return Result.Error("Pawns can't move through occupied cells");
                }
            }

			return Result.Ok;
		}
	}
}
