using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndGraphCommonLib
{
    public class graphnode
    {
        public int value { get; set; }
        public List<graphnode> children { get; set; }

        public bool visited { get; set; }
        public graphnode(int value)
        {
            this.visited = false;
            this.value = value;
            this.children = new List<graphnode>();
        }
    }
}
