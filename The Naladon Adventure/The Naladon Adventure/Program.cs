using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Naladon_Adventure.Parser;
using The_Naladon_Adventure.View_Drawing;

namespace The_Naladon_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPageText testPage = GeneralParser.getInstance().readPageText("TEST.txt");
            testPage.drawPage(true, true);
            System.Console.ReadLine();



        }
    }
}
