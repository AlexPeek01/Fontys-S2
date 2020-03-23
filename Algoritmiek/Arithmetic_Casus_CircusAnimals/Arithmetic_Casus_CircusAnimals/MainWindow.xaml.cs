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
        
         
        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            Train.CreateTrain(Train.GetTrainCount());
            string animalString = "";
            Wagon.PlaceAnimalsInWagon(MainLogic.SortList(Animal.oldAnimalList), Train.GetTrainCount());
            foreach (Wagon w in Wagon.wagonList)
            {
                DisplayBox.Text += "Wagon: " + w._wagonId.ToString() + " Contains:" + '\n';
                for (int i = 0; i < w.animalsInWagon.Count(); i++)
                    animalString += "   - " +  w.animalsInWagon[i]._animalName + '\n';
                DisplayBox.Text += animalString + '\n';
                animalString = "";
            }
            efficiencyLabel.Content = "Space efficiency: " + Math.Round(MainLogic.CalculateEfficiency(), 3).ToString() + "%";
            Wagon.wagonList.Clear();
        }
        private void SmallHerbBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(false, 1, "Small_Herbivore");
            SmallHerbBtn.Content = (Convert.ToInt32(SmallHerbBtn.Content) + 1).ToString();
        }

        private void SmallCarnBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(true, 1, "Small_Carnivore");
            SmallCarnBtn.Content = (Convert.ToInt32(SmallCarnBtn.Content) + 1).ToString();
        }

        private void MediumHerbBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(false, 3, "Medium_Herbivore");
            MediumHerbBtn.Content = (Convert.ToInt32(MediumHerbBtn.Content) + 1).ToString();
        }

        private void MediumCarnBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(true, 3, "Medium_Carnivore");
            MediumCarnBtn.Content = (Convert.ToInt32(MediumCarnBtn.Content) + 1).ToString();
        }

        private void LargeHerbBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(false, 5, "Large_Herbivore");
            LargeHerbBtn.Content = (Convert.ToInt32(LargeHerbBtn.Content) + 1).ToString();
        }

        private void LargeCarnBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal.CreateAnimal(true, 5, "Large_Carnivore");
            LargeCarnBtn.Content = (Convert.ToInt32(LargeCarnBtn.Content) + 1).ToString();
        }
    }
}
