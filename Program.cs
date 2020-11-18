using System;

namespace dijkstraConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Entrez le nombre de noeuds");
                var entry = Console.ReadLine();
                int size;
                
                if (!int.TryParse(entry, out size))
                {
                    Console.WriteLine("The entry is not an Integer");
                }
                else
                {
                    System dijkstra = new System(Int32.Parse(entry));
                    dijkstra.PrintPath();
                    break;
                }
            }
        }
    }
}