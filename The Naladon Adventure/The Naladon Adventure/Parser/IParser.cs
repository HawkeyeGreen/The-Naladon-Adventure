using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Naladon_Adventure.View_Drawing;

namespace The_Naladon_Adventure.Parser
{
    interface IParser
    {
        AbstractPageText readPageText(string path);
        AbstractMenuItemTextBody readMenuItem(string path);
    }
}
