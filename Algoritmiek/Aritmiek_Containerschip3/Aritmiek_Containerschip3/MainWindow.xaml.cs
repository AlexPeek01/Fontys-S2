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

namespace Aritmiek_Containerschip3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Container> containerList = new List<Container>();
        public MainWindow()
        {
            InitializeComponent();
            Ship ship = new Ship(4, 4, 4);
            for(int i = 0; i < 64; i++)
            {
                Container container = new Container(false, false, 15000);
                ship.unsortedContainerList.Add(container);
                containerList = Ship.SortContainerList(ship.unsortedContainerList);
            }
        }
    }
}
