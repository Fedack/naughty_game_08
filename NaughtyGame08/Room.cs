using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Controls;

namespace NaughtyGame08
{
    class Room
    {
        public string Name { get; set; }
        public double ID { get; set; }
        public double ParentId { get; set; }
        public string Description { get; set; }
        public List<string> Text { get; set; }
        public List<Run> Run { get; set; }
        public List<ModInlineUIContainer> Link { get; set; }
        public bool HasVisited { get; set; }

        public Room(string name, double id, double parentid)
        {
            Run = new List<Run>();
            Text = new List<string>();
            Link = new List<ModInlineUIContainer>();
            Name = name;
            ID = id;
            ParentId = parentid;
        }

        public static void AddTextToRoom(List<string> Text, Room room)
        {
            foreach(string t in Text)
            {
                room.Text.Add(t);
                room.Run.Add(CreateRun(t));
            }
        }
        
        public static ModInlineUIContainer CreateContainer(string text, Action mouseDoubleClick)
        {
            var label = new InlineLabel(text);
            var container = new ModInlineUIContainer(label);

            label.MouseDoubleClick += (s, e) => mouseDoubleClick();

            return container;
        }

        public static Run CreateRun(string text)
        {
            Run run = new Run(text);
            return run;
        }
    }
}
