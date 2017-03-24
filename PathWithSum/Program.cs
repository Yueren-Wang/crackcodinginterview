using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace PathWithSum
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

            int res1 = FindPathWithSumFromNode(node1, 1);
            int res2 = FindPathWithSumFromNode(node1, 2);
            int res3 = FindPathWithSumFromNode(node1, 3);
            int res4 = FindPathWithSumFromNode(node1, 4);
            int res5 = FindPathWithSumFromNode(node1, 5);
            int res6 = FindPathWithSumFromNode(node1, 6);
            int res7 = FindPathWithSumFromNode(node1, 7);
            int res8 = FindPathWithSumFromNode(node1, 8);
            int res9 = FindPathWithSumFromNode(node1, 9);
            int res10 = FindPathWithSumFromNode(node1, 10);
            int res11 = FindPathWithSumFromNode(node1, 11);
        }

        private static int FindPathWithSumFromNode(node root, int sum)
        {
            if(root == null)
            {
                return 0;
            }

            if(sum == root.value)
            {
                return FindPathWithSumFromNode(root.left, 0) + FindPathWithSumFromNode(root.right, 0) + 1;
            }

            return FindPathWithSumFromNode(root.left, sum - root.value) + FindPathWithSumFromNode(root.right, sum-root.value);
        }

        private static int FindAllPathWithSum(node root, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            return FindPathWithSumFromNode(root, sum) + FindAllPathWithSum(root.left, sum) + FindAllPathWithSum(root.right, sum);

        }
    }
}
