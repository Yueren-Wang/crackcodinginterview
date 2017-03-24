using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace TreeAndGraphProject
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

            List<LinkedList<node>> res = transformBTtolinkedlistByLevel(node1);

        }

        static List<LinkedList<node>> transformBTtolinkedlistByLevel (node root)
        {
            List<LinkedList<node>> result = new List<LinkedList<node>>();
            Queue<node> q = new Queue<node>();
            int nexLevelcount = 0;
            int curlevelcount = 0;
            if(root!=null)
            {
                q.Enqueue(root);
                curlevelcount++;
            }

            while(q.Count!= 0)
            {
                LinkedList<node> l = new LinkedList<node>();
                for (int i = 0; i < curlevelcount; i++)
                {
                    node n = q.Dequeue();
                    l.AddLast(n);
                    if (n.left != null)
                    {
                        q.Enqueue(n.left);
                        nexLevelcount++;
                    }

                    if (n.right != null)
                    {
                        q.Enqueue(n.right);
                        nexLevelcount++;
                    }
                }
                result.Add(l);
                int temp = nexLevelcount;
                curlevelcount = temp;
                nexLevelcount = 0;
            }
            return result;
        }
    }
}
