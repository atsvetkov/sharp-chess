namespace Chess
{
	struct Cell
	{
		public char X { get; }
		public int Y { get; }

		public Cell(string cell) : this(cell[0], int.Parse(cell[1].ToString()))
		{
		}

		public Cell(char col, int row)
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

        public override bool Equals(object obj) => obj is Cell cell && cell.X == X && cell.Y == Y;

		public static bool operator ==(Cell c1, Cell c2) => c1.Equals(c2);
		public static bool operator !=(Cell c1, Cell c2) => !c1.Equals(c2);
    }
}
