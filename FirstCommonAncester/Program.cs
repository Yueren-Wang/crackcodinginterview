using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace FirstCommonAncester
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

            node a = new node();

            node f1 = FirstCommonAncester(node1, node5, node7); // node 1
            node f2 = FirstCommonAncester(node1, node4, node5); // node 2
            node f3 = FirstCommonAncester(node1, node4, node3); // node 1
            node f4 = FirstCommonAncester(node1, node4, a); // null

        }

        private static node FirstCommonAncester(node root, node n1, node n2)
        {
            if(isExistinSubTree(root.left, n1)&&isExistinSubTree(root.right,n2))
            {
                return root;
            }

            if(isExistinSubTree(root.left, n1)&&isExistinSubTree(root.left,n2))
            {
                return FirstCommonAncester(root.left, n1, n2);
            }

            if(isExistinSubTree(root.right,n1)&&isExistinSubTree(root.right,n2))
            {
                return FirstCommonAncester(root.right, n1, n2);

            }

            return null;
        }

        private static bool isExistinSubTree(node root, node n)
        {
            if(root == n)
            {
                return true;
            }

            if(root == null)
            {
                return false;
            }

            return isExistinSubTree(root.left, n) || isExistinSubTree(root.right, n);
        }


    }
}
