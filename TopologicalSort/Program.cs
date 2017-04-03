using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;


namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            graph g = new graph();
            graphnode node5 = new graphnode(5);
            graphnode node4 = new graphnode(4);
            graphnode node2 = new graphnode(2);
            graphnode node0 = new graphnode(0);
            graphnode node1 = new graphnode(1);
            graphnode node3 = new graphnode(3);
            g.graphnodelist = new List<graphnode>
            {
                node5,
                node4,
                node2,
                node0,
                node1,
                node3
            };

            g.addDirectedEdge(node5, node2);
            g.addDirectedEdge(node5, node0);
            g.addDirectedEdge(node4, node0);
            g.addDirectedEdge(node4, node1);
            g.addDirectedEdge(node2, node3);
            g.addDirectedEdge(node3, node1);

            Stack<int> s = new Stack<int>();

            topologicalSort(g, ref s);

            Console.WriteLine(s.ToList());
        }

        private static List<int> topologicalSort(graph g, ref Stack<int> s)
        {
            foreach (graphnode node in g.graphnodelist)
            {
                if (!node.visited)
                {
                    topologicalSortHelper(node, ref s);
                    node.visited = true;
                }
            }

            return s.ToList();
        }

        private static void topologicalSortHelper(graphnode node, ref Stack<int> stack)
        {
            foreach(graphnode n in node.children)
            {
                if(!n.visited)
                {
                    topologicalSortHelper(n, ref stack);
                }
            }

            stack.Push(node.value);
            node.visited = true;
        }


    }
}
