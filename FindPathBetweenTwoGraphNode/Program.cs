using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace FindPathBetweenTwoGraphNode
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

            bool res = FindPathBetweenTwoGraphNode(node5, node1);
            graph.resetGraphnodevistedboolean(g);
            bool res2 = FindPathBetweenTwoGraphNode(node2, node1);
            graph.resetGraphnodevistedboolean(g);
            bool res3 = FindPathBetweenTwoGraphNode(node5, node4);

        }

        private static bool FindPathBetweenTwoGraphNode(graphnode node1, graphnode node2)
        {
            return BFStoFindPath(node1, node2);
        }

        public static bool BFStoFindPath(graphnode source, graphnode dest)
        {
            List<int> res = new List<int>();

            if (source == null)
            {
                return false;
            }

            Queue<graphnode> q = new Queue<graphnode>();
            res.Add(source.value);
            source.visited = true;
            q.Enqueue(source);
            while (q.Count != 0)
            {
                graphnode cur = q.Dequeue();
                if (cur == dest) return true;
                cur.visited = true;
                foreach (graphnode n in cur.children)
                {
                    if (!n.visited)
                    {
                        q.Enqueue(n);
                    }
                }
            }
            return false;
        }
    }
}
