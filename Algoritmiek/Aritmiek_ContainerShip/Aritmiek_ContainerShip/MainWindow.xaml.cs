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

namespace Aritmiek_ContainerShip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Container> sortedContainerList = new List<Container>();
        Ship ship;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ConfirmBTN_Click(object sender, RoutedEventArgs e)
        {
            ship = new Ship(int.Parse(LengthTextBox.Text), int.Parse(WidthTextBox.Text), int.Parse(HeightTextbox.Text));
        }

        private void AddContainerBTN_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked1 = false;
            bool isChecked2 = false;
            if(isValuableCheckbox.IsChecked == true)
            {
                isChecked1 = true;
            }
            if (isCooledCheckbox.IsChecked == true)
            {
                isChecked2 = true;
            }
            Domain.CreateContainer(int.Parse(ContainerWeightTextbox.Text), isChecked1, isChecked2);
            isChecked1 = false;
            isChecked2 = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sortedContainerList = Domain.SortContainer(Container.unsortedContainerList);
            Array.Clear(ship.position, 0, ship.position.Length);
            foreach (Container c in sortedContainerList)
            {
                Domain.PlaceContainer(sortedContainerList, ship);
            }
        }
    }
}
