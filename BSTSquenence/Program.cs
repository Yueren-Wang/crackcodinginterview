using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace BSTSquenence
{
    class Program
    {
        static void Main(string[] args)
        {
            node node3 = new node(3, null, null);
            node node1 = new node(1, null, null);
            node node2 = new node(2, node1, node3);

            List<List<int>> res = BSTSequence(node3);
        }

        private static List<List<int>> wrappingTwoArray(List<int> l1, List<int> l2)
        {
            List<List<int>> res = new List<List<int>>();
            if(l1==null||l2==null)
            {
                res.Add(l1==null?l2:l1);
                return res;
            }
            int left = l1[0];
            List<List<int>> r1 = wrappingTwoArray(truncateList(l1), l2);
            r1.ForEach(l => l.Insert(0, left));
            res.Concat(r1).ToList();
            left = l2[0];
            List<List<int>> r2 = wrappingTwoArray(l1, truncateList(l2));
            r2.ForEach(l => l.Insert(0, left));
            res.Concat(r2).ToList();
            return res;


        }

        private static List<int> truncateList(List<int> l)
        {

            return l.Count == 1 ? null : l.GetRange(1, l.Count - 1);

        }

        private static List<List<int>> BSTSequence(node node)
        {
            List<List<int>> res = new List<List<int>>();

            if (node == null)
            {
                res.Add(new List<int>());
                return res;
            }

            List<List<int>> left = BSTSequence(node.left);
            List<List<int>> right = BSTSequence(node.right);
            foreach (var i in left)
            {
                foreach(var j in right)
                {
                    res.Concat(wrappingTwoArray(i, j));
                }
            }

            res.ForEach(i => i.Insert(0, node.value));
            return res;
        }
    }
}
