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
            for (int i = 0; i < 13; i++)
            {
                Logic.Container c1 = new Logic.Container(10000+i, true, false, false, false);
                ship.ContainerList.Add(c1);
            }
            for (int i = 0; i < 3; i++)
            {
                Logic.Container c2 = new Logic.Container(10010 + i, true, true, false, false);
                ship.ContainerList.Add(c2);
            }
            for (int i = 0; i < 43; i++)
            {
                Logic.Container c3 = new Logic.Container(10000 + i, false, false, false, false);
                ship.ContainerList.Add(c3);
            }
            for (int i = 0; i < 5; i++)
            {
                Logic.Container c = new Logic.Container(10000 + i, false, true, false, false);
                ship.ContainerList.Add(c);
            }
            Algorithm.placeContainerArray(ship);
        }
    }
}
