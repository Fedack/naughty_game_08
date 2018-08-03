using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;

namespace NaughtyGame08
{
    class InlineLabel : Label
    {
        public InlineLabel(string content)
        {
            Content = content;
            Foreground = Brushes.Blue;
            Padding = new Thickness(0, 0, 0, 0);
        }
    }
    class ModInlineUIContainer : InlineUIContainer
    {
        public ModInlineUIContainer(UIElement uielement)
        {
            BaselineAlignment = BaselineAlignment.Bottom;
            Child = uielement;
        }
    }
}
