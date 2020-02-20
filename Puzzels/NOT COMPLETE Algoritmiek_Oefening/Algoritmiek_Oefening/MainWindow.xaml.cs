using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Algoritmiek_Oefening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Product defaultProduct2 = new Product("Vans Oldschool", 19.99);
            Product defaultProduct = new Product("Nike Airmax", 9.99);
            Order.productList.Add(defaultProduct2);
            Order.productList.Add(defaultProduct);
        }
        private void HighestPriceBTN_Click(object sender, RoutedEventArgs e)
        {
            ProductBox.Text = "Most expensive: " + Convert.ToString(Order.GiveMaximumPrice());
        }

        private void AllProductsBTN_Click(object sender, RoutedEventArgs e)
        {
            ProductBox.Text = "";
            double minimumPrice = 0;
            foreach(Product p in Order.GetAllProducts(minimumPrice))
            {
                if(p!= null)
                { ProductBox.Text += p.name + " - " + p.price.ToString() + '\n'; }
            }
        }
        private void AvgPriceBTN_Click(object sender, RoutedEventArgs e)
        {
            ProductBox.Text = "Average price: " + Convert.ToString(Order.GiveAveragePrice());
        }
    }
}
