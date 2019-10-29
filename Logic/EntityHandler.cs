using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class EntityHandler
    {
        public static void CreateNewCategory(string name)
        {
            try
            {
                List<Object> categories = new List<Object>();
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
    }
}
