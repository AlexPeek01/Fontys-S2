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

namespace Arithmetic_Casus_CircusAnimals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddLionBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(true, 3, "lion", false);
        }

        private void AddElephantBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(false, 5, "elephant", false);
        }

        private void AddMonkeyBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(false, 1, "monkey", false);
        }

        private void AddTigerBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(true, 3, "tiger", false);
        }

        private void AddZebraBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(false, 3, "zebra", false);
        }

        private void AddLlamaBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(false, 3, "llama", false);
        }

        private void AddCamelBTN_Click(object sender, RoutedEventArgs e)
        {
            Domain.CreateAnimal(false, 3, "camel", false);
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            string animalString = "";
            Domain.PlaceAnimalInWagon();
            foreach (Wagon w in Wagon.wagonList)
            {
                DisplayBox.Text += "Wagon: " + w.wagonId.ToString() + " Contains:" + '\n';
                for (int i = 0; i < w.animalsInWagon.Count(); i++)
                {
                    animalString += w.animalsInWagon[i].animalName + '\n';
                }
                DisplayBox.Text += animalString + '\n';
                animalString = "";
            }
            efficiencyLabel.Content = "Space efficiency: " + Domain.CalculateEfficiency().ToString() + "%";
        }
    }
}
