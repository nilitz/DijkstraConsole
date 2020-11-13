using System;

namespace djikstra
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nombre de noeuds");
            System dijkstra = new System("mySystem", Int32.Parse(Console.ReadLine()));
        }
    }
}