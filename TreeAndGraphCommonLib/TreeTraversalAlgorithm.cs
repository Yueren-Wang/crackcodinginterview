using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndGraphCommonLib
{
    public static class TreeTraversalAlgorithm
    { // using static class as utility/helper. static class can not be instantiated or inherited, to access member, simply use TreeTraversalAlgorithm.BFS() etc
        public static List<int> BFS(graphnode g)
        {
            List<int> res = new List<int>();

            if (g == null)
            {
                return res;
            }

            Queue<graphnode> q = new Queue<graphnode>();
            res.Add(g.value);
            g.visited = true;
            q.Enqueue(g);
            while (q.Count != 0)
            {
                graphnode cur = q.Dequeue();
                res.Add(cur.value);
                cur.visited = true;
                foreach (graphnode n in cur.children)
                {
                    if (!n.visited)
                    {
                        q.Enqueue(n);
                    }
                }
            }
            return res;
        }
    }
}
