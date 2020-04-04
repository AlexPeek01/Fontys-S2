using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace ContainerShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ship ship = new Ship(4, 4, 4, 0, 0);
            for (int i = 0; i < 5; i++)
            {
                Logic.Container c = new Logic.Container(10000+i, true, false, false);
                ship.ContainerList.Add(c);
            }
            for (int i = 0; i < 5; i++)
            {
                Logic.Container c = new Logic.Container(10000 + i, false, false, false);
                ship.ContainerList.Add(c);
            }
            for (int i = 0; i < 5; i++)
            {
                Logic.Container c = new Logic.Container(10000 + i, true, true, false);
                ship.ContainerList.Add(c);
            }
            for (int i = 0; i < 5; i++)
            {
                Logic.Container c = new Logic.Container(10000 + i, false, true, false);
                ship.ContainerList.Add(c);
            }
            Algorithm.placeContainerArray(ship);
        }
    }
}
