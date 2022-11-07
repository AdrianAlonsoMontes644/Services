namespace Ejercicio1Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] notes = { 2, 4, 6, 1, 10, 3, 7, 9, 8, 5};
            Array.ForEach(notes, x =>
            {
                Console.ForegroundColor = x >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student note: {x}");
            });
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int res = Array.FindIndex(notes, x => x >= 5);
            Console.WriteLine($"The first student that approved is the number {res + 1} in the list.");
            bool SomeoneDidIt = Array.Exists(notes, x => x >= 5);
            if (SomeoneDidIt)
            {
                Console.WriteLine("Somebody approved");
            }
            else
            {
                Console.WriteLine("No one approved... That´s lame...");
            }
            int lastOne = Array.FindLastIndex(notes, x => x >= 5);

            Console.WriteLine($"The last student that approved the test is the {lastOne + 1}th one");
            Array.ForEach(notes, x => Console.WriteLine($"The inverse notes are: {1.0 / x}"));
            Console.ReadKey();
        }
    }
}
