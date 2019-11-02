using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using SharedModels;

namespace Logic
{
    public class EntityHandler
    {

        SerializerService serializer = new SerializerService();
        CategoryDatabase cDB = new CategoryDatabase();
        PodcastDatabase pDB = new PodcastDatabase();
        public List<Category> dezerialisedCategories;

        //public override void deserializePod()
        //{
        //        cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\poddar.txt");
        //        this.dezerialisedCategories = cDB.categoryDb;
        //}
        public bool IfFileExists(string filename)
        {
            bool fileExists = false;
            if(File.Exists(filename)) {
                fileExists = true;
            }
            return fileExists;
        }

        public void AddNewCategoryToList(string newCategory)
        {
            if (IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                cDB.AddCategory(newCategory);
                serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
            } else
            {
                cDB.AddCategory(newCategory);
                serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
            }
        }

        public void RemoveCategoryFromList(string categoryName) 
        {
            cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
            var namn = cDB.categoryDb.FirstOrDefault(x => x.CategoryName == categoryName);
            cDB.categoryDb.Remove(namn);
            serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
        }

        public void ChangeCategoryFromList(string categoryName, string changedCategoryName)
        {
            cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
            var category = cDB.categoryDb.FirstOrDefault(x => x.CategoryName == categoryName);
            category.CategoryName = changedCategoryName;
            serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
        }

        public void RemovePodcastFromList(string podcastName)
        {
            try
            {
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                Podcast podcastRemoved = pDB.Podcasts.FirstOrDefault(a => a.Title == podcastName);
                pDB.Podcasts.Remove(podcastRemoved);
                serializer.Serialize(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ChangePodcastFromList(string podcastName, string url, string freq, string category)
        {
            try
            {
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                Podcast podcastChanged = pDB.Podcasts.FirstOrDefault(a => a.Title == podcastName);
                podcastChanged.Url = url;
                podcastChanged.UpdateFrequency = freq;
                podcastChanged.categories = cDB.AddCategory(category);
                serializer.Serialize(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            }
            catch(Exception e)
            {

            }
        }

        public List<string> fillCategoryDropBox()
        {
            string hej = "finns ingen kategori";
            List<string> categoryAsString = new List<string>();

            if (IfFileExists(@"C:\podFeeds\categories.txt")) { 
            cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
            
            foreach (Category category in cDB.categoryDb)
            {
                categoryAsString.Add(category.CategoryName);
            }
            return categoryAsString;

        } else
            {
                categoryAsString.Add(hej);
                return categoryAsString;
            }
        }
    }
}
