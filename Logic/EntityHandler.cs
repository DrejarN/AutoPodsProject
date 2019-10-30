using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class EntityHandler
    {

        SerializerService serializer = new SerializerService();
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
                List<Category> categoryList = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                Category category = new Category(newCategory);
                categoryList.Add(category);
                serializer.Serialize(@"C:\podFeeds\categories.txt", categoryList);
            } else
            {
                List<Category> categoryList = new List<Category>();
                Category category = new Category(newCategory);
                categoryList.Add(category);
                serializer.Serialize(@"C:\podFeeds\categories.txt", categoryList);
            }
        }

        public void RemoveCategoryFromList(string categoryName) 
        {
            List<Category> categoryList = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
            var namn = categoryList.FirstOrDefault(x => x.CategoryName == categoryName);
            categoryList.Remove(namn);
            serializer.Serialize(@"C:\podFeeds\categories.txt", categoryList);
        }

        public void CreateNewCategory(string name)
        {
            try
            {
               /* List<Object> categories = new List<Object>();
                categories = SerializerService.Deserialize(@"C:\podFeeds\categories");
                Category category = new Category(name);
                categories.Add(name);
                SerializerService.Serialize(@"C:\podFeeds\categories", categories);


                /*
                List<Category> categories = new List<Category>();
                Category category = new Category(name);
                categories.Add(category);
                SerializerService.SerializerCategories(categories);
                */

            } catch (Exception ex)
            {
                throw new Exception(ex + "Kunde ej skapa kategori");
            }
        }

        public void testMetod()
        {
            List<object> enlista = new List<object>();
            Category category = new Category("Hejhopp");
            enlista.Add(category);

            serializer.Serialize(@"C:\podFeeds\categories.txt", enlista);
        }

        public void testMetod2()
        {
            List<Category> nylista = serializer.Deserialize<Category>(@"C:\podFeeds\categories");
            Category category = new Category("Hejhoppv2");
            nylista.Add(category);
            serializer.Serialize(@"C:\podFeeds\categories.txt", nylista);
        }

    }
}
