namespace TextRpg.Src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(57, 40);
            Console.SetBufferSize(57, 40);
            Game game = new Game();
        }
    }
}