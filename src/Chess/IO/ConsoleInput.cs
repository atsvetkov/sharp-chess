using System;

namespace Chess
{
    class ConsoleInput : IInput
	{
		public string Read(string prompt)
		{
			Console.SetCursorPosition(0, 12);
			Console.Write(new string(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, 12);
			Console.Write(prompt + ' ');

			return Console.ReadLine();
		}
	}
}
