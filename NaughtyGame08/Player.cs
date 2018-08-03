using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtyGame08
{
    class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
        public bool HasKnot { get; set; }

        public Player()
        {
            Inventory = new List<Item>();
        }

    }
}
