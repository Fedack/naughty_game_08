using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtyGame08
{
    class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsCarried { get; set; }
        public List<string> Attributes { get; set; }

        public Item(int id, string name)
        {
            ID = id;
            Name = name;
            Attributes = new List<string>();
        }
        public Item(int id, string name, bool iscarried)
        {
            ID = id;
            Name = name;
            IsCarried = iscarried;
            Attributes = new List<string>();
        }
    }
}
