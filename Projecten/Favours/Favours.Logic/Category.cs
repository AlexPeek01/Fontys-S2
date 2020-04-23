using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Category
    {
        private int categoryId;
        private string categoryName;
        public Category(string _categoryName)
        {
            this.categoryName = _categoryName;
        }
    }
}
