using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace CheckSubTree
{
    class Program
    {
        static void Main(string[] args)
        {
            node node4 = new node(4, null, null);
            node node5 = new node(5, null, null);
            node node6 = new node(6, null, null);
            node node7 = new node(7, null, null);
            node node2 = new node(2, node4, node5);
            node node3 = new node(3, node6, node7);
            node node1 = new node(1, node2, node3);



            bool res = isSubTree(node1, node2);


        }


        private static bool isSubTree(node big, node small)
        {
            List<node> n = new List<node>();
            List<int> bigdata = traversalAndStoreValueInList(big, ref n);
            List<int> smalldata = traversalAndStoreValueInList(small, ref n);

            return node.isSubList(smalldata, bigdata);
        }

        private static List<int> traversalAndStoreValueInList(node node, ref List<node> res)
        {
            node.preorderTraversal(node, ref res, true);
            List<int> l = new List<int>();
            res.ForEach(e => l.Add(e.value));
            return l;

        }

         
    }
}
