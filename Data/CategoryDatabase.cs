﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}     
