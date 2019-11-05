using System;
using System.Diagnostics;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;

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
            if (fieldName == "")
            {
                emptyField = false;
            }
            return emptyField;
        }

        public bool IfFeedIsValidFormat(string url)
        {
            try
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));

                foreach (SyndicationItem item in feed.Items)
                {
                    Debug.Print(item.Title.Text);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool IfItemNotSelected(int index)
        {
            bool item = false;
            if (index > 0)
            {
                item = true;
            }
            return item;
        }

        public void CreateDirectory()
        {
            if (!System.IO.Directory.Exists(@":C\podFeeds"))
            {
                System.IO.Directory.CreateDirectory(@":C\podFeeds");
            }
        }
    }
}
