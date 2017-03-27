using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndGraphCommonLib
{
    public class node
    {
        public int value { get; set; }
        public node left { get; set; }
        public node right { get; set; }
        public node(int value, node left, node right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public node()
        {
        }

        private static void preorderTraversal(node node, ref List<node> res, bool keepNullLeaf)
        {
            if (node == null)
            {
                if (keepNullLeaf)
                {
                    node n = new node();
                    res.Add(n);
                }
                return;
            }

            res.Add(node);
            preorderTraversal(node.left, ref res, keepNullLeaf);
            preorderTraversal(node.right, ref res, keepNullLeaf);

        }
    }

   

}
