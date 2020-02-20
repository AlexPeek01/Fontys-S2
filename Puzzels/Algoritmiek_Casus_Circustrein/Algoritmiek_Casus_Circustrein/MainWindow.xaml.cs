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

namespace Algoritmiek_Casus_Circustrein
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Animal lion = new Animal(true, 3);
            Animal.animalList.Add(lion);
            TrainWagon wagon1 = new TrainWagon(false, 10);
            TrainWagon.trainWagonList.Add(wagon1);
        }

        private void SortBTN_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
