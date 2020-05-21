namespace Chess
{
	struct Cell
	{
		public char X { get; }
		public int Y { get; }

		public Cell(string cell) : this(cell[0], int.Parse(cell[1].ToString()))
		{
		}

		private Cell(char col, int row)
		{
			X = col;
			Y = row;
		}

		public static bool TryParse(string cell, out Cell result)
		{
			result = default;
			if (string.IsNullOrWhiteSpace(cell) || cell.Length != 2 || cell[0] < 'a' || cell[0] > 'h' || cell[1] < '1' || cell[1] > '8')
			{
				return false;
			}

			result = new Cell(cell[0], int.Parse(cell[1].ToString()));
			return true;
		}

		public override string ToString() => $"{(char)('a' + X)}{Y}";
	}
}
