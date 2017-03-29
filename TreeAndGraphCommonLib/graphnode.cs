using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndGraphCommonLib
{
    class graphnode
    {
        public int value { get; set; }
        public List<graphnode> children { get; set; }

        public bool visited { get; set; }
        public graphnode()
        {
            this.visited = false;
        }
    }
}
