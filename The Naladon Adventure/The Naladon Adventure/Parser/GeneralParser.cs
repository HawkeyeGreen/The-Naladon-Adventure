using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using The_Naladon_Adventure.View_Drawing;

namespace The_Naladon_Adventure.Parser
{
    /* Der einfache Grundparser
     * Er benutzt das Singleton-Pattern, um stets von über all aufrufbar zu sein.
     * Dieser Parser beachtet keinerlei dynamischen Texte o.ä., sondern liest nur statische Text-Blocke.
     * Dynamische Parameter werden stumpf eingelesen und Teil des Textkörpers gemacht.
     */
    class GeneralParser : IParser
    {
        static GeneralParser Instance;

        public static GeneralParser getInstance()
        {
            if(Instance == null)
            {
                Instance = new GeneralParser();
            }
            return Instance;
        }

        private GeneralParser()
        {

        }

        // Der hiermit eingelesene MenuItemTextBody ist statisch
        public AbstractMenuItemTextBody readMenuItem(string path)
        {
            throw new NotImplementedException();
        }

        public AbstractPageText readPageText(string path)
        {
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + path))
            {
                return readPage(path);
            }
            else
            {
                string newPath = tryFallbackLocations(path);
                if(newPath != "Page not found")
                {
                   
                }
                StaticPageText fallbackPage = new StaticPageText();
                fallbackPage.addLine("Die gesuchte Seite konnte nicht unter dem Pfad " + path + " gefunden werden. Auch die Fallback-Orte enthielten keine Ensprechung.");
                return fallbackPage;
            }
        }

        private AbstractPageText readPage(string path)
        {
            StaticPageText pageText = new StaticPageText();
            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + path));
            string currentLine = Convert.ToString(reader.ReadLine());
            while (currentLine != "TextBody-Begin" && !reader.EndOfStream)
            {
                currentLine = Convert.ToString(reader.ReadLine());
            }
            if (currentLine == "TextBody-Begin")
            {
                pageText.Lines = readTextBody(reader);
            }
            pageText.Source = path;
            return pageText;
        }

        private string tryFallbackLocations(string path)
        {
            return "Page not found";
        }

        private List<string> readTextBody(StreamReader reader)
        {
            List<string> results = new List<string>();
            string currentLine = Convert.ToString(reader.ReadLine());

            if(currentLine != "TextBody-End")
            {
                results.Add(currentLine);
                results.AddRange(readTextBody(reader));
                return results;
            }
            return results;
        }
    }
}
