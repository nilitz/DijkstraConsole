using System;

namespace djikstra
{
    public class Link
    {
        public Node[] nodes = new Node[2];
        public int weight { get; set; }

        public Link(Node nodeA, Node nodeB)
        {
            nodes[0] = nodeA;
            nodes[1] = nodeB;
            weight = (int)Math.Sqrt(Math.Pow((nodeB.x - nodeA.x), 2) + Math.Pow((nodeB.y - nodeA.y), 2));
        }

        public void printLink()
        {
            Console.WriteLine("A : " + nodes[0].id);
            Console.WriteLine("B : " + nodes[1].id);
            Console.WriteLine("Poids : " + weight);
        }

    }
}