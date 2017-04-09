using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndGraphCommonLib
{
    public class graph
    {

        public int V { get; set; } //no of vertices
        public List<graphnode> graphnodelist{get; set;} // adjacent list

        public void addDirectedEdge (graphnode node1, graphnode node2 )
        {
            node1.children.Add(node2);
        }

        public void addIndirectedEdge(graphnode node1, graphnode node2)
        {
            this.graphnodelist.Where(n => n == node1).FirstOrDefault().children.Add(node2);
            this.graphnodelist.Where(n => n == node2).FirstOrDefault().children.Add(node1);

        }

        public static void resetGraphnodevistedboolean(graph g)
        {
            g.graphnodelist.ForEach(n => n.visited = false);
        }

    }
}
