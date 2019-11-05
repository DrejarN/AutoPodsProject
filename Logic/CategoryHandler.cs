using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data;
using SharedModels;

namespace Logic
{
    public class CategoryHandler : PodcastHandler, IPod
    {
        List<Category> deserializedCategory;
        public new string filenameForJson { get; set; }

        public CategoryHandler()
        {
            this.filenameForJson = @"C:\podFeeds\categories.txt";
            deserializeList(filenameForJson);
        }

        public override void deserializeList(string filename)
        {
            if (validate.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                this.deserializedCategory = cDB.categoryDb;
            }
        }
        public void AddNewCategoryToList(string newCategory)
        {
            if (validate.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                cDB.categoryDb = deserializedCategory;
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
            cDB.categoryDb = deserializedCategory;
            Category category = cDB.categoryDb.FirstOrDefault(x => x.CategoryName == categoryName);
            cDB.RemoveFromList(category);
            serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
            deserializeList(filenameForJson);
        }

        public void ChangeCategoryFromList(string categoryName, string changedCategoryName)
        {
            var category = cDB.categoryDb.FirstOrDefault(x => x.CategoryName == categoryName);
            category.CategoryName = changedCategoryName;
            serializer.Serialize(@"C:\podFeeds\categories.txt", cDB.categoryDb);
            deserializeList(filenameForJson);
        }
        public List<string> FillCategoryList() //Måste fixas.
        {
            List<string> CategoryNameList = new List<string>();
            if (validate.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                cDB.categoryDb = deserializedCategory;
                foreach (Category category in cDB.categoryDb)
                {
      
                    CategoryNameList.Add(category.CategoryName);
                }
            } 
            return CategoryNameList;
        }
    }
}
