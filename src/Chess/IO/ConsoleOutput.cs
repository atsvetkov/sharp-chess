using System;
using System.Text;

namespace Chess
{
    class ConsoleOutput : IOutput
	{
		//private const string _pieceSymbols = "♔♕♖♗♘♙♚♛♜♝♞♟︎";
		private const string _pieceSymbols = "KQRBNPkqrbnp";

		public void Display(Board board)
		{
			Console.Clear();
			var text = BoardToString(board);
			Console.WriteLine(text);
			Console.WriteLine();
		}

		private string BoardToString(Board board)
		{
			var sb = new StringBuilder();
			for (var row = 7; row >= 0; row--)
			{
				sb.Append(row + 1);
				sb.Append(' ');
				for (var col = 0; col < 8; col++)
				{
					if (board.TryGetPiece(new Cell($"{(char)('a' + col)}{row + 1}"), out (Piece, Color) value))
					{
						(Piece piece, Color color) = value;
						sb.Append(_pieceSymbols[(int)piece + (color == Color.White ? 0 : 6)]);
					}
					else
					{
						sb.Append(".");
					}
				}

				sb.Append(Environment.NewLine);
			}

			sb.Append(Environment.NewLine);
			sb.Append("  ");
			for (var col = 0; col < 8; col++)
			{
				sb.Append((char)('a' + col));
			}

			sb.Append(Environment.NewLine);

			return sb.ToString();
		}

		public void Message(string message)
		{
			Console.WriteLine(message);
		}

		public void UpdateStatus(string status)
		{
			Console.SetCursorPosition(0, 11);
			Console.Write(new string(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, 11);
			Console.WriteLine(status);
		}
	}
}
