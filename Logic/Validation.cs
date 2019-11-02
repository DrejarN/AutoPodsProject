using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Validation
    {
        public bool IfFileExists(string filename)
        {
            bool fileExists = false;
            if (File.Exists(filename))
            {
                fileExists = true;
            }
            return fileExists;
        }

        public bool IfStringFieldEmpty(string fieldName)
        {
            bool emptyField = true;
            if (fieldName == "") //||
            {
                emptyField = false;
            }
            return emptyField;
        }

        public bool IfUrlCorrectFormat(string url)
        {
            bool isRss = false;
            if (url.EndsWith("/rss"))
            {
                isRss = true;
            }
            return isRss;
        }
    }



    //Valideringar:
    // Om fil existerar (Poddar och kategorier)
    // Om ett fält är tomt
    // Om podcastfeed är rätt format ( /rss på slutet av url)

}
