using System.Collections.Generic;

using SharedModels;

namespace Data
{
    public class CategoryDatabase
    {
        public List<Category> categoryDb { get; set; }
        
        public CategoryDatabase()
        {
            categoryDb = new List<Category>();
        }

        public Category AddCategory(string category)
        {
            Category newCategory = new Category(category);
            categoryDb.Add(newCategory);
            return newCategory;
        }

        public Category AddCategory(Category category)
        {
            categoryDb.Add(category);
            return category;
        }

        public void RemoveFromList(Category category)
        {
            categoryDb.Remove(category);
        }
    }
}     

