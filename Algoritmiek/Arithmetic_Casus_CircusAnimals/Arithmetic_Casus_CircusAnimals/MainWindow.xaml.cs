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
        Stopwatch stopWatch;
        public MainWindow()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            Algorithm run = new Algorithm();
            stopWatch.Start();
            train = run.PlaceAnimalsInTrain(CreateAnimals());
            stopWatch.Stop();
            DisplayBox.Text = "";
            string animalString = "";
            string time = stopWatch.Elapsed.ToString();
            foreach (Wagon w in train._wagonsInTrain)
            {
                DisplayBox.Text += "Wagon: " + w._wagonId.ToString() + " Contains:" + '\n';
                for (int i = 0; i < w._animalList.Count(); i++)
                    animalString += "   - " + w._animalList[i]._animalName + '\n';
                DisplayBox.Text += animalString + '\n';
                animalString = "";
            }
            efficiencyLabel.Content = "Space efficiency: " + Math.Round(MainLogic.CalculateEfficiency(train), 1).ToString() + "%";
        }
        public List<Animal> CreateAnimals()
        {
            List<Animal> animalList = new List<Animal>();
            for (int i = 0; i < Int32.Parse(LCTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(true, 5, "Large_Carnivore"));
            }
            for (int i = 0; i < Int32.Parse(LHTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(false, 5, "Large_Herbivore"));
            }
            for (int i = 0; i < Int32.Parse(MCTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(true, 3, "Medium_Carnivore"));
            }
            for (int i = 0; i < Int32.Parse(MHTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(false, 3, "Medium_Herbivore"));
            }
            for (int i = 0; i < Int32.Parse(SCTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(true, 1, "Small_Carnivore"));
            }
            for (int i = 0; i < Int32.Parse(SHTextBox.Text); i++)
            {
                animalList.Add(Animal.CreateAnimal(false, 1, "Small_Herbivore"));
            }
            return animalList;

        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (train != null)
                train.SaveTrainToDb(train);
        }
    }
}
