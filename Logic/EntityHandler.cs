using System;
using System.Collections.Generic;
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
                List<Category> categories = new List<Category>();
                Category category = new Category(name);
                categories.Add(category);
                SerializerService.SerializerCategories();

            } catch (Exception ex)
            {
                throw new Exception(ex + "Kunde ej skapa kategori");
            }
        }
    }
}
