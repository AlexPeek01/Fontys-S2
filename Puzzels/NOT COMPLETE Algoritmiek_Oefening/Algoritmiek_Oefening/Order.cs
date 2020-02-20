using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek_Oefening
{
    class Order
    {
        public static Product[] productArray = new Product[10];
        public static double GiveMaximumPrice()
        {
            double currentHighest = productArray[0].price;
            foreach(Product p in productArray)
            {
                if(p.price > currentHighest)
                currentHighest = p.price;
            }
            return currentHighest;
        }
        public static double GiveAveragePrice()
        {
            double priceSum = 0;
            int productCounter = 0;
            for(int i = 0; i< productArray.Length; i++)
            {
                if (productArray[i] != null)
                {
                    priceSum += productArray[i].price;
                    productCounter++;
                }
            }
            return priceSum/productCounter;
        }
        public static Product[] GetAllProducts(double minimumPrice)
        {
            return productArray;
        }
        public static void SortProductsByPrice()
        {

        } 
    }
}
