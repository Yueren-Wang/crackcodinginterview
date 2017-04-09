using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAndGraphCommonLib;

namespace SerializeDeserializeBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "X";
            node root = deserialize(ref data);
        }

        public static node deserialize(ref string data)
        {
            if (data == null)
            {
                return null;
            }
            if (data[0] == 'X')
            {
                data = data.Substring(1, data.Length - 1);
                return null;
            }
            node n = new node(int.Parse(data[0].ToString()),null,null);
            data = data.Substring(1, data.Length - 1);
            n.left = deserialize(ref data);
            n.right = deserialize(ref data);
            return n;
        }
    }
}
