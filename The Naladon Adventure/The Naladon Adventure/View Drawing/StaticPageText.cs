using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Naladon_Adventure.View_Drawing
{
    // Ein statischer Textkörper, der eine einzelne, unveränderliche Seite darstellt.
    class StaticPageText : AbstractPageText
    {
        private string source;

        public StaticPageText()
        {
            Lines = new List<string>();
            source = "nicht festgelegt";
        }

        public string Source
        {
            get => source;
            set => source = value;
        }

        public override void addLine(string line) => Lines.Add(line);

        public override void drawPage(bool clear_window = true, bool debug_mode = false)
        {
            if(clear_window) { System.Console.Clear(); }
            if(debug_mode) { System.Console.WriteLine(source); }
            foreach(string line in Lines) { System.Console.WriteLine(line); }
        }
    }


}
