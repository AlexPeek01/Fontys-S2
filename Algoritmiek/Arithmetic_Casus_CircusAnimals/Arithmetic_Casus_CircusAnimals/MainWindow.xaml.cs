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
            #region SetAmounts
            int[] amountOfEachAnimal = new int[6];
            amountOfEachAnimal[0] = Int32.Parse(SCTextBox.Text);
            amountOfEachAnimal[1] = Int32.Parse(MCTextBox.Text);
            amountOfEachAnimal[2] = Int32.Parse(LCTextBox.Text);
            amountOfEachAnimal[3] = Int32.Parse(SHTextBox.Text);
            amountOfEachAnimal[4] = Int32.Parse(MHTextBox.Text);
            amountOfEachAnimal[5] = Int32.Parse(LHTextBox.Text);
            #endregion
            train = run.PlaceAnimalsInTrain(logic.CreateAnimals(amountOfEachAnimal), new Train());
            DisplayBox.Text = logic.CreateOutputString(train);
            efficiencyLabel.Content = "Space efficiency: " + Math.Round(logic.CalculateEfficiency(train), 1).ToString() + "%";
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (train != null)
                train.SaveTrainToDb();
        }
    }
}
