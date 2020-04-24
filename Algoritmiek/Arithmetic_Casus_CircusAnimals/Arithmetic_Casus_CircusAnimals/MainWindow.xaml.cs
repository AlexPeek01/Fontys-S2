using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;
using Arithmetic_Casus_CircusAnimals;
using LogicLayer;

namespace Arithmetic_Casus_CircusAnimals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Train train;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            MainLogic logic = new MainLogic();
            Algorithm run = new Algorithm();
            train = run.PlaceAnimalsInTrain(CreateAnimals());
            DisplayBox.Text = logic.CreateOutputString(train);
            efficiencyLabel.Content = "Space efficiency: " + Math.Round(logic.CalculateEfficiency(train), 1).ToString() + "%";
        }
        private List<Animal> CreateAnimals()
        {
            #region CreateAnimals
            List<Animal> animalList = new List<Animal>();
            for (int i = 0; i < Int32.Parse(LCTextBox.Text); i++)
            {
                Animal animal = new Animal(true, Animal.size.Large, "Large_Carnivore");
                animalList.Add(animal);
            }
            for (int i = 0; i < Int32.Parse(LHTextBox.Text); i++)
            {
                Animal animal = new Animal(false, Animal.size.Large, "Large_Herbivore");
                animalList.Add(animal);
            }
            for (int i = 0; i < Int32.Parse(MCTextBox.Text); i++)
            {
                Animal animal = new Animal(true, Animal.size.Medium, "Medium_Carnivore");
                animalList.Add(animal);
            }
            for (int i = 0; i < Int32.Parse(MHTextBox.Text); i++)
            {
                Animal animal = new Animal(false, Animal.size.Medium, "Medium_Herbivore");
                animalList.Add(animal);
            }
            for (int i = 0; i < Int32.Parse(SCTextBox.Text); i++)
            {
                Animal animal = new Animal(true, Animal.size.Small, "Small_Carnivore");
                animalList.Add(animal);
            }
            for (int i = 0; i < Int32.Parse(SHTextBox.Text); i++)
            {
                Animal animal = new Animal(false, Animal.size.Small, "Small_Herbivore");
                animalList.Add(animal);
            }
            #endregion
            return animalList;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (train != null)
                train.SaveTrainToDb();
        }
    }
}
