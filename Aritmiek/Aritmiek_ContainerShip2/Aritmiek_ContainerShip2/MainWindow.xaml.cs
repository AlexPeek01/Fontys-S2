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

namespace Aritmiek_ContainerShip2
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
        // if containertoplace > 1.2 * otherweight or < 0.8 dan niet plaatsen
        private void AddContainerBTN_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked1 = false;
            bool isChecked2 = false;
            if (isValuableCheckbox.IsChecked == true)
                isChecked1 = true;
            if (isCooledCheckbox.IsChecked == true)
                isChecked2 = true;
            if (!Domain.ContainerLimitReached(isChecked1, isChecked2, ship.length, ship.width, ship.height, Container.unsortedContainerList))
            {
                Domain.CreateContainer(int.Parse(ContainerWeightTextbox.Text), isChecked1, isChecked2);
            }
            /*if (cooledContainerCount <= ship.width * ship.height && isCooledCheckbox.IsChecked == true)
                Domain.CreateContainer(int.Parse(ContainerWeightTextbox.Text), isChecked1, isChecked2);
            else if (isCooledCheckbox.IsChecked != true)
                Domain.CreateContainer(int.Parse(ContainerWeightTextbox.Text), isChecked1, isChecked2);
            else
                System.Windows.MessageBox.Show("Cooled container limit reached!");
        */}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sortedContainerList = Domain.SortContainer(Container.unsortedContainerList);
            Array.Clear(ship.leftSideArray, 0, ship.leftSideArray.Length);
            Array.Clear(ship.centerArray, 0, ship.centerArray.Length);
            Array.Clear(ship.rightSideArray, 0, ship.rightSideArray.Length);
                Domain.PlaceContainer(sortedContainerList, ship);
        }
    }
}
