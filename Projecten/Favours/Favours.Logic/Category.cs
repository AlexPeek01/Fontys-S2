using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Category
    {
        private int categorieId { get; set; }
        private string categorieNaam { get; set; }
        public Category(string _categorieNaam)
        {
            this.categorieNaam = _categorieNaam;
        }
    }
}
