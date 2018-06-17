using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Naladon_Adventure.View_Drawing
{
    abstract class AbstractPageText
    {
        private List<string> lines;
        public List<string> Lines
        {
            get => lines;
            set => lines = value;
        }

        abstract public void addLine(string line);

        abstract public void drawPage(bool clear_window = true, bool debug_mode = false);
    }
}
