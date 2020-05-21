namespace Chess
{
	interface IOutput
	{
		void Display(Board board);
		void Message(string message);
		void UpdateStatus(string status);
	}
}
