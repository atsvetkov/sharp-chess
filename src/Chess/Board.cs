using System.Collections.Generic;

namespace Chess
{
	class Board
	{
		private readonly Dictionary<Cell, (Piece, Color)> _pieces = new Dictionary<Cell, (Piece, Color)>
		{
			// pawns
			[new Cell("a2")] = (Piece.Pawn, Color.White),
			[new Cell("b2")] = (Piece.Pawn, Color.White),
			[new Cell("c2")] = (Piece.Pawn, Color.White),
			[new Cell("d2")] = (Piece.Pawn, Color.White),
			[new Cell("e2")] = (Piece.Pawn, Color.White),
			[new Cell("f2")] = (Piece.Pawn, Color.White),
			[new Cell("g2")] = (Piece.Pawn, Color.White),
			[new Cell("h2")] = (Piece.Pawn, Color.White),
			[new Cell("a7")] = (Piece.Pawn, Color.Black),
			[new Cell("b7")] = (Piece.Pawn, Color.Black),
			[new Cell("c7")] = (Piece.Pawn, Color.Black),
			[new Cell("d7")] = (Piece.Pawn, Color.Black),
			[new Cell("e7")] = (Piece.Pawn, Color.Black),
			[new Cell("f7")] = (Piece.Pawn, Color.Black),
			[new Cell("g7")] = (Piece.Pawn, Color.Black),
			[new Cell("h7")] = (Piece.Pawn, Color.Black),
			// knights
			[new Cell("b1")] = (Piece.Knight, Color.White),
			[new Cell("g1")] = (Piece.Knight, Color.White),
			[new Cell("b8")] = (Piece.Knight, Color.Black),
			[new Cell("g8")] = (Piece.Knight, Color.Black),
			// bishops
			[new Cell("c1")] = (Piece.Bishop, Color.White),
			[new Cell("f1")] = (Piece.Bishop, Color.White),
			[new Cell("c8")] = (Piece.Bishop, Color.Black),
			[new Cell("f8")] = (Piece.Bishop, Color.Black),
			// rooks
			[new Cell("a1")] = (Piece.Rook, Color.White),
			[new Cell("h1")] = (Piece.Rook, Color.White),
			[new Cell("a8")] = (Piece.Rook, Color.Black),
			[new Cell("h8")] = (Piece.Rook, Color.Black),
			// queens
			[new Cell("d1")] = (Piece.Queen, Color.White),
			[new Cell("d8")] = (Piece.Queen, Color.Black),
			// kings
			[new Cell("e1")] = (Piece.King, Color.White),
			[new Cell("e8")] = (Piece.King, Color.Black)
		};

		public (Piece, Color) GetPiece(Cell cell) => _pieces[cell];

		public bool TryGetPiece(Cell cell, out (Piece, Color) coloredPiece)
		{
			if (_pieces.TryGetValue(cell, out (Piece, Color) value))
			{
				coloredPiece = value;
				return true;
			}

			coloredPiece = default;
			return false;
		}

		public bool IsOccupied(Cell cell) => _pieces.ContainsKey(cell);

		public MoveRecord ApplyMoveCommand(MoveCommand move)
		{
			if (!_pieces.TryGetValue(move.From, out (Piece, Color) coloredPiece))
			{
				throw new ChessException("The 'from' cell is empty");
			}

			_pieces[move.To] = coloredPiece;
			_pieces.Remove(move.From);
			var (piece, color) = coloredPiece;

			return new MoveRecord(color, piece, move.From, move.To);
		}
	}
}
