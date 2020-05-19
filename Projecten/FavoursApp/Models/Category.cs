using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        private string CategoryName { get; set; }
        public Category(string _categoryName)
        {
            this.CategoryName = _categoryName;
        }
    }
}
