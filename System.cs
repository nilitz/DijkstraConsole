using System;
using System.Collections.Generic;

namespace dijkstraConsole
{
    public class System
    {
        private List<Link> path;

        public List<Link> Path
        {
            get => path;
            set => path = value;
        }
        
        public System(int size)
        {
            path = SystemDijkstra(SystemCreation(size), size);
        }


        public void PrintPath()
        {
            foreach (var link in path)
            {
                link.printLink();
            }
        }
        
        /*
         * Creating our System of links & nodes
         * @return List<Link>
         */
        private List<Link> SystemCreation(int size)
        {
            var random = new Random();
            List<Link> linksList = new List<Link>();
            List<Node> nodesList = new List<Node>();

            for (int j = 0; j < size; j++)
            {
                nodesList.Add(new Node(random.Next(100), random.Next(100), j));
            }

            foreach (Node node in nodesList)
            {
                for (int k = 1; k <= 3; k++)
                {
                    if (node.id + k < nodesList.Count)
                    {
                        linksList.Add(new Link(node, nodesList[node.id + k]));
                    }
                }
            }
            return linksList;
        }

        /*
         * Application of Dijkstra Algorithm to the System
         */
        private List<Link> SystemDijkstra(List<Link> links, int size)
        {
            //Variables definition
            //form : (Link, Origin, Total Weight)
            var storedLinks = new List<Tuple<Link, int, int>>();
            var chosenLinks = new List<Tuple<Link, int, int>>();
            var savedTuple = new Tuple<Link, int, int>(new Link(), 0, 0);
            int actualNodeId = 0;
            int totalWeight = 0;
            int iteration = 0;
            int? minimalWeight;

            List<int> passedNodes = new List<int>();

            //Finding the path
            while (passedNodes.Count != size - 1)
            {

                //Finding every available links from a point
                foreach (Link link in links)
                {
                    if ((link.nodes[0].id == actualNodeId || link.nodes[1].id == actualNodeId) && !passedNodes.Contains(link.nodes[0].id) && !passedNodes.Contains(link.nodes[1].id))
                    {
                        storedLinks.Add(new Tuple<Link, int, int>(link, actualNodeId, totalWeight + link.weight));
                    }
                }

                minimalWeight = null;

                //Finding the best link (minimal weight from every link)
                foreach (Tuple<Link, int, int> tupleLink in storedLinks)
                {

                    //Condition for a link to be chosen
                    if ((!passedNodes.Contains(tupleLink.Item1.nodes[0].id) || tupleLink.Item1.nodes[1].id != actualNodeId)
                        &&
                        (!passedNodes.Contains(tupleLink.Item1.nodes[1].id) || tupleLink.Item1.nodes[0].id != actualNodeId)
                        &&
                        (!passedNodes.Contains(tupleLink.Item1.nodes[0].id) || !passedNodes.Contains(tupleLink.Item1.nodes[1].id)))
                    {
                        if (!minimalWeight.HasValue || tupleLink.Item3 < minimalWeight)
                        {
                            minimalWeight = tupleLink.Item3;
                            savedTuple = tupleLink;
                        }
                    }
                }

                chosenLinks.Add(savedTuple);
                totalWeight = minimalWeight ?? default(int);

                passedNodes.Add(actualNodeId);

                //Choose the next actualNodeId between the two of the link.
                if (passedNodes.Contains(chosenLinks[iteration].Item1.nodes[0].id))
                {
                    actualNodeId = chosenLinks[iteration].Item1.nodes[1].id;
                }
                else
                {
                    actualNodeId = chosenLinks[iteration].Item1.nodes[0].id;
                }

                iteration++;
            }

            var sortedLinks = SortingSystemDijkstra(chosenLinks);
            return sortedLinks;
        }

        /*
         * Sorting the Tuple returned by SystemDijkstra
         * @return List<Link>
         */
        private List<Link> SortingSystemDijkstra(List<Tuple<Link, int, int>> unsortedList)
        {
            List<Link> sortedList = new List<Link>();
            int precedentNode = unsortedList.Count;
            bool loop = true;
            while (loop)
            {
                foreach (var tuple in unsortedList)
                {
                    if (tuple.Item1.nodes[1].id == precedentNode)
                    {
                        sortedList.Add(tuple.Item1);
                        if (tuple.Item2 == 0)
                        {
                            loop = false;
                            break;
                        }
                        precedentNode = tuple.Item2;
                        break;
                    }
                }
            }
            sortedList.Reverse();
            return sortedList;
        }
    }
}