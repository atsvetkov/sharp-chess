namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ConsoleGameController(new ConsoleInput(), new ConsoleOutput());
            controller.Start();
        }
    }
}
