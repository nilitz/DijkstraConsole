namespace dijkstraConsole
{
    public class Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public int id { get; set; }

        public Node()
        {
            
        }
        public Node(int x, int y, int id)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }


    }
}